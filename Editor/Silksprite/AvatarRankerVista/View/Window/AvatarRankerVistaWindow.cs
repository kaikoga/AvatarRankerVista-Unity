using System;
using System.Linq;
using nadena.dev.ndmf.runtime;
using Silksprite.AvatarRankerVista.Core;
using Silksprite.AvatarRankerVista.Core.Serialized;
using Silksprite.AvatarRankerVista.Core.Utils;
using Silksprite.AvatarRankerVista.View.UIElements;
using Silksprite.AvatarRankerVista.Window;
using UnityEditor;
using UnityEngine;
using UnityEngine.UIElements;

namespace Silksprite.AvatarRankerVista.View.Window
{
    class AvatarRankerVistaWindow : EditorWindow
    {
        SerializedAvatarName[] _currentAvatarNames = {};
        readonly SerializedAvatarReportList _serializedAvatarReportList = new SerializedAvatarReportList();

        AvatarRankerVistaWindowView _view;

        [InitializeOnLoadMethod]
        static void InitializeOnLoad()
        {
            SerializedAvatarReportRepository.instance.Changed += ShowWindowIfRequested;
        }

        void CreateGUI()
        {
            _view = new AvatarRankerVistaWindowView();
            rootVisualElement.Add(_view);
            _view.AvatarRootObjectField.RegisterValueChangedCallback(evt => ManualReport(evt.newValue as GameObject));
            _view.ShowFullReport.RegisterValueChangedCallback(evt => OnShowFullReportChanged(evt.newValue));
            _view.AvatarNameList.selectionChanged += selectedItems  => OnAvatarNameSelected(selectedItems.OfType<SerializedAvatarName>().ToArray());
            _view.ClearReportsButton.clicked += OnClearReportsClicked;
            _view.SceneAvatarsPopup.RegisterValueChangedCallback(evt => OnSceneAvatarSelected(evt.newValue));
            _view.RegulationList.Draw(RegulationRepository.Instance.AllRegulations().ToList());
            AvatarRankerSettingsRepository.instance.Changed += Refresh;
            SerializedAvatarReportRepository.instance.Changed += Refresh;
            EditorApplication.hierarchyChanged += OnHierarchyChanged;
            RefreshSceneAvatarsPopup();
        }
        
        void OnEnable()
        {
            titleContent = new GUIContent("Avatar Ranker Vista");
        }

        void OnDisable()
        {
            AvatarRankerSettingsRepository.instance.Changed -= Refresh;
            SerializedAvatarReportRepository.instance.Changed -= Refresh;
            EditorApplication.hierarchyChanged -= OnHierarchyChanged;
        }

        void OnHierarchyChanged()
        {
            RefreshSceneAvatarsPopup();
        }

        void OnShowFullReportChanged(bool newValue)
        {
            AvatarRankerSettingsRepository.instance.ShowFullReport = newValue;
        }

        void OnAvatarNameSelected(SerializedAvatarName[] selectedAvatarNames)
        {
            if (selectedAvatarNames.Length == 0)
            {
                return;
            }
            _currentAvatarNames = selectedAvatarNames;
            Refresh();
        }

        void OnClearReportsClicked()
        {
            SerializedAvatarReportRepository.instance.Clear();
        }

        void OnSceneAvatarSelected(GameObject avatarRootObject)
        {
            if (_view.SceneAvatarsPopup.index < 0)
            {
                return;
            }
            ManualReport(avatarRootObject);
            _view.SceneAvatarsPopup.index = -1;
        }

        void ManualReport(GameObject avatarRootObject)
        {
            if (avatarRootObject)
            {
                AvatarReportService.MeasureAll(avatarRootObject, false);
                _currentAvatarNames = new []{ new SerializedAvatarName
                    {
                        sceneName = avatarRootObject.scene.name,
                        name = avatarRootObject.name
                    }
                };
            }
            else
            {
                _currentAvatarNames = Array.Empty<SerializedAvatarName>();
            }
            Refresh();
        }

        void Refresh()
        {
            _serializedAvatarReportList.avatarReports = SerializedAvatarReportRepository.instance.ForAvatars(_currentAvatarNames).ToArray();
            if (_view != null)
            {
                _view.AvatarNameList.itemsSource = SerializedAvatarReportRepository.instance.AvatarNames.ToList();
                _view.AvatarReportListView.Draw(_serializedAvatarReportList);
            }
        }

        void RefreshSceneAvatarsPopup()
        {
            if (_view != null)
            {
#if ARV_NDMF
                _view.SceneAvatarsPopup.choices = RuntimeUtil.FindAvatarRoots().ToList();
#else
                _view.SceneAvatarsPopup.style.display = DisplayStyle.None;
#endif
                _view.SceneAvatarsPopup.SetEnabled(!Application.isPlaying);
            }
        }

        static void ShowWindowIfRequested()
        {
            if (AvatarRankerSettingsRepository.instance.ShowReportOnBuild)
            {
                ShowWindow();
            }
        }

        public static void ShowWindow()
        {
            (GetWindow<AvatarRankerVistaWindow>() ?? CreateInstance<AvatarRankerVistaWindow>()).Show();
        }
    }
}
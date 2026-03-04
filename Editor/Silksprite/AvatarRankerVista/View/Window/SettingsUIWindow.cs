using System.Linq;
using Ablet;
using Silksprite.AvatarRankerVista.Core;
using Silksprite.AvatarRankerVista.Core.Serialized;
using Silksprite.AvatarRankerVista.Core.Utils;
using Silksprite.AvatarRankerVista.View.UIElements;
using UnityEditor;
using UnityEngine.UIElements;

namespace Silksprite.AvatarRankerVista.View.Window
{
    public class SettingsUIWindow : VisualElement
    {
        const string UxmlPath = "Packages/net.kaikoga.arv/Editor/Silksprite/AvatarRankerVista/View/Uxml/SettingsUIWindow.uxml";

        public SettingsUIWindow()
        {
            var container = AssetDatabase.LoadAssetAtPath<VisualTreeAsset>(UxmlPath).CloneTree();
            hierarchy.Add(container);
            var regulationListView = container.Q<RegulationListView>("regulationList");
            regulationListView.Draw(RegulationRepository.Instance.AllRegulations().ToList());

            var showReferenceBuilds = container.Q<Toggle>("showReferenceBuildsToggle");
            showReferenceBuilds.value = AvatarRankerSettingsRepository.instance.ShowReferenceBuilds;
            showReferenceBuilds.RegisterValueChangedCallback(evt => OnShowReferenceBuildsChanged(evt.newValue));
            
            var showFullReport = container.Q<Toggle>("showFullReportToggle");
            showFullReport.value = AvatarRankerSettingsRepository.instance.ShowFullReport;
            showFullReport.RegisterValueChangedCallback(evt => OnShowFullReportChanged(evt.newValue));

            var manualMeasureButton = container.Q<Button>("manualMeasureButton");
            manualMeasureButton.clicked += OnManualMeasure;
        }

        void OnManualMeasure()
        {
            foreach (var avatar in AbletFacade.GetSceneEntrypoints(false))
            {
                AvatarReportService.MeasureAll(avatar.gameObject, false);
            }
        }

        void OnShowFullReportChanged(bool newValue)
        {
            AvatarRankerSettingsRepository.instance.ShowFullReport = newValue;
        }

        void OnShowReferenceBuildsChanged(bool newValue)
        {
            AvatarRankerSettingsRepository.instance.ShowReferenceBuilds = newValue;
        }
    }
}

using System.Linq;
using Silksprite.AvatarRankerVista.Core;
using Silksprite.AvatarRankerVista.Core.Serialized;
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

            var showFullReport = container.Q<Toggle>("showFullReportToggle");
            showFullReport.value = AvatarRankerSettingsRepository.instance.ShowFullReport;
            
            showFullReport.RegisterValueChangedCallback(evt => OnShowFullReportChanged(evt.newValue));
            regulationListView.Draw(RegulationRepository.Instance.AllRegulations().ToList());
        }
        
        void OnShowFullReportChanged(bool newValue)
        {
            AvatarRankerSettingsRepository.instance.ShowFullReport = newValue;
        }
    }
}

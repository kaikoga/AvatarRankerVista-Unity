using Silksprite.AvatarRankerVista.Core.Serialized;
using UnityEditor;
using UnityEditor.UIElements;
using UnityEngine.UIElements;

namespace Silksprite.AvatarRankerVista.View.UIElements
{
    class AvatarRankerVistaWindowView : VisualElement
    {
        const string UxmlPath = "Packages/net.kaikoga.arv/Editor/Silksprite/AvatarRankerVista/View/Uxml/AvatarRankerVistaWindowView.uxml";
        const string UssPath = "Packages/net.kaikoga.arv/Editor/Silksprite/AvatarRankerVista/View/Uxml/AvatarRankerVista.uss";

        public readonly RegulationListView RegulationList;
        public readonly Toggle ShowFullReport;
        public readonly ListView AvatarNameList;
        public readonly Button ClearReportsButton;
        public readonly GameObjectPopupField SceneAvatarsPopup;
        public readonly ObjectField AvatarRootObjectField;
        public readonly SerializedAvatarReportListView AvatarReportListView;
        
        public AvatarRankerVistaWindowView()
        {
            styleSheets.Add(AssetDatabase.LoadAssetAtPath<StyleSheet>(UssPath));
            var container = AssetDatabase.LoadAssetAtPath<VisualTreeAsset>(UxmlPath).CloneTree();
            container.style.flexGrow = 1;
            RegulationList = container.Q<RegulationListView>("regulationList");
            ShowFullReport = container.Q<Toggle>("showFullReport");
            AvatarNameList = container.Q<ListView>("avatarNameList");
            ClearReportsButton = container.Q<Button>("clearReports");
            SceneAvatarsPopup = container.Q<GameObjectPopupField>("sceneAvatarsPopup");
            AvatarRootObjectField = container.Q<ObjectField>("avatarRootObjectField");
            AvatarReportListView = container.Q<SerializedAvatarReportListView>("avatarReportListView");
            hierarchy.Add(container);

            ShowFullReport.SetValueWithoutNotify(AvatarRankerSettingsRepository.instance.ShowFullReport);
        }
    }
}

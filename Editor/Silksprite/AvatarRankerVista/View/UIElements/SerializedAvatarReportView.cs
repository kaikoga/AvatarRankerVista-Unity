using System.Linq;
using Silksprite.AvatarRankerVista.Core;
using Silksprite.AvatarRankerVista.Core.Serialized;
using Silksprite.Loch.UIElements.Tools;
using UnityEditor;
using UnityEngine.UIElements;

namespace Silksprite.AvatarRankerVista.View.UIElements
{
    class SerializedAvatarReportView : VisualElement
    {
        const string UxmlPath = "Packages/net.kaikoga.arv/Editor/Silksprite/AvatarRankerVista/View/Uxml/SerializedAvatarReportView.uxml";

        readonly Label _avatarOriginText;
        readonly Label _avatarOverallLevelText;
        readonly VisualElement _resultContainer;
        
        public SerializedAvatarReportView()
        {
            var container = AssetDatabase.LoadAssetAtPath<VisualTreeAsset>(UxmlPath).CloneTree();
            container.Localize<SerializedAvatarReportView>();
            _avatarOriginText = container.Q<Label>("avatarOriginText");
            _avatarOverallLevelText = container.Q<Label>("avatarOverallLevelText");
            _resultContainer = container.Q<VisualElement>("resultContainer");
            hierarchy.Add(container);
        }

        public void Draw(SerializedAvatarReport avatarReport)
        {
            _avatarOriginText.text = $"{avatarReport.regulation.displayName} ({avatarReport.origin.ToString()}): ";
            _avatarOverallLevelText.text = avatarReport.overallLevel.displayName;
            _avatarOverallLevelText.ClearClassList();
            _avatarOverallLevelText.AddToClassList("prop-level");
            _avatarOverallLevelText.style.borderLeftColor = RegulationRepository.Instance.GetRegulation(avatarReport.regulation.id).GetLevel(avatarReport.overallLevel.id).Color;
            _resultContainer.Clear();

            var results = AvatarRankerSettingsRepository.instance.ShowFullReport
                ? avatarReport.result
                : avatarReport.result.Where(result => result.level.id == avatarReport.overallLevel.id);

            foreach (var entry in results)
            {
                var entryView = new SerializedAvatarReportEntryView();
                entryView.Draw(entry);
                _resultContainer.Add(entryView);
            }
        }
    }
}

using System.Linq;
using Silksprite.AvatarRankerVista.Core.Serialized;
using Silksprite.AvatarRankerVista.Window;
using UnityEditor;
using UnityEngine.UIElements;

namespace Silksprite.AvatarRankerVista.View.UIElements
{
    class SerializedAvatarReportView : VisualElement
    {
        const string UxmlPath = "Packages/net.kaikoga.arv/Editor/Silksprite/AvatarRankerVista/View/Uxml/SerializedAvatarReportView.uxml";

        readonly Label _avatarNameText;
        readonly Label _avatarStatusText;
        readonly VisualElement _resultContainer;
        
        public SerializedAvatarReportView()
        {
            var container = AssetDatabase.LoadAssetAtPath<VisualTreeAsset>(UxmlPath).CloneTree();
            _avatarNameText = container.Q<Label>("avatarNameText");
            _avatarStatusText = container.Q<Label>("avatarStatusText");
            _resultContainer = container.Q<VisualElement>("resultContainer");
            hierarchy.Add(container);
        }

        public void Draw(SerializedAvatarReport avatarReport)
        {
            _avatarNameText.text = avatarReport.avatarName.FullName;
            _avatarStatusText.text = $"{avatarReport.regulation.displayName} ({avatarReport.origin.ToString()}): {avatarReport.overallLevel.displayName}";
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

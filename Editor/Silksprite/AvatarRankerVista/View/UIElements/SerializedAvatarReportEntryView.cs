using Silksprite.AvatarRankerVista.Window;
using UnityEditor;
using UnityEngine.UIElements;

namespace Silksprite.AvatarRankerVista.View.UIElements
{
    class SerializedAvatarReportEntryView : VisualElement
    {
        const string UxmlPath = "Packages/net.kaikoga.arv/Editor/Silksprite/AvatarRankerVista/View/Uxml/SerializedAvatarReportEntryView.uxml";

        readonly Label _criterionText;
        readonly Label _criterionValueText;
        readonly Label _levelText;
        readonly Label _recommendStatusText;
        
        public SerializedAvatarReportEntryView()
        {
            var container = AssetDatabase.LoadAssetAtPath<VisualTreeAsset>(UxmlPath).CloneTree();
            _criterionText = container.Q<Label>("criterionText");
            _criterionValueText = container.Q<Label>("criterionValueText");
            _levelText = container.Q<Label>("levelText");
            _recommendStatusText = container.Q<Label>("recommendStatusText");
            hierarchy.Add(container);
        }

        public void Draw(SerializedAvatarReportEntry entry)
        {
            _criterionText.text = entry.criterion.displayName;
            _criterionValueText.text = entry.criterion.value;
            _levelText.text = entry.level.displayName;
            _levelText.ClearClassList();
            _levelText.AddToClassList("prop-level");
            _levelText.AddToClassList(entry.level.id);

            if (string.IsNullOrEmpty(entry.recommendedValue))
            {
                _recommendStatusText.style.display = DisplayStyle.None; 
            }
            else
            {
                _recommendStatusText.style.display = DisplayStyle.Flex;
                _recommendStatusText.text = $"({entry.recommendedValue} for {entry.recommendedLevel.displayName})";
            }
        }
    }
}

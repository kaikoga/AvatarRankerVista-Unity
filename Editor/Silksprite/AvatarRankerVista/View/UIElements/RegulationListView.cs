using System.Collections.Generic;
using Silksprite.AvatarRankerVista.Core;
using Silksprite.AvatarRankerVista.Core.Serialized;
using UnityEditor;
using UnityEngine.UIElements;

namespace Silksprite.AvatarRankerVista.View.UIElements
{
    class RegulationListView : ListView
    {
        public RegulationListView()
        {
            makeItem = () => new RegulationListItemView();
            bindItem = (element, index) => ((RegulationListItemView)element).Draw((Regulation)itemsSource[index]);
        }
        
        public void Draw(List<Regulation> regulations)
        {
            itemsSource = regulations;
        }
        
        public new class UxmlFactory : UxmlFactory<RegulationListView, UxmlTraits>
        {
        }
    }

    class RegulationListItemView : VisualElement
    {
        const string UxmlPath = "Packages/net.kaikoga.arv/Editor/Silksprite/AvatarRankerVista/View/Uxml/RegulationListEntryView.uxml";

        readonly Toggle _toggle;
        readonly Label _label;
        Regulation _regulation;

        public RegulationListItemView()
        {
            var container = AssetDatabase.LoadAssetAtPath<VisualTreeAsset>(UxmlPath).CloneTree();
            _toggle = container.Q<Toggle>("toggle");
            _toggle.RegisterValueChangedCallback(OnToggleChanged);
            _label = container.Q<Label>("label");
            hierarchy.Add(container);
        }

        public void Draw(Regulation regulation)
        {
            _regulation = regulation;
            _label.text = regulation.DisplayName;
            _toggle.value = AvatarRankerSettingsRepository.instance.GetRegulationEnabled(regulation);
        }
        
        void OnToggleChanged(ChangeEvent<bool> evt)
        {
            AvatarRankerSettingsRepository.instance.SetRegulationEnabled(_regulation, evt.newValue);
        }

        public new class UxmlFactory : UxmlFactory<RegulationListView, UxmlTraits>
        {
        }
    }
}

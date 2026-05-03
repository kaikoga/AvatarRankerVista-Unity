using UnityEngine;
using UnityEngine.UIElements;

#if !UNITY_2022_OR_NEWER
using UnityEditor.UIElements;
#endif

namespace Silksprite.AvatarRankerVista.View.UIElements
{
#if UNITY_2023_2_OR_NEWER
    [UxmlElement] partial 
#endif
    class GameObjectPopupField : PopupField<GameObject>
    {
        public GameObjectPopupField()
        {
            formatListItemCallback = gameObject => gameObject ? gameObject.name : "";
            formatSelectedValueCallback = gameObject => gameObject ? gameObject.name : "";
        }

#if !UNITY_2023_2_OR_NEWER
        public new class UxmlFactory : UxmlFactory<GameObjectPopupField, UxmlTraits>
        {
        }
#endif
    }
}

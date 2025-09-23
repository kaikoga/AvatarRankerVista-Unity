using UnityEngine;
using UnityEngine.UIElements;

namespace Silksprite.AvatarRankerVista.View.UIElements
{
    sealed class GameObjectPopupField : PopupField<GameObject>
    {
        public GameObjectPopupField()
        {
            formatListItemCallback = gameObject => gameObject ? gameObject.name : "";
            formatSelectedValueCallback = gameObject => gameObject ? gameObject.name : "";
        }

        public new class UxmlFactory : UxmlFactory<GameObjectPopupField, UxmlTraits>
        {
        }
    }
}

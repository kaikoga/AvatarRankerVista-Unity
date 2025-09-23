using Silksprite.AvatarRankerVista.Core.Serialized;
using UnityEngine.UIElements;

namespace Silksprite.AvatarRankerVista.View.UIElements
{
    class SerializedAvatarReportListView : VisualElement
    {
        public void Draw(SerializedAvatarReportList list)
        {
            hierarchy.Clear();
            foreach (var avatarReport in list.avatarReports)
            {
                var avatarReportView = new SerializedAvatarReportView();
                avatarReportView.Draw(avatarReport);
                hierarchy.Add(avatarReportView);
            }
        }
        
        public new class UxmlFactory : UxmlFactory<SerializedAvatarReportListView, UxmlTraits>
        {
        }
    }
}

using Silksprite.AvatarRankerVista.Core.Serialized;
using UnityEngine.UIElements;

namespace Silksprite.AvatarRankerVista.View.UIElements
{
#if UNITY_2023_2_OR_NEWER
    [UxmlElement] partial 
#endif
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

#if !UNITY_2023_2_OR_NEWER
        public new class UxmlFactory : UxmlFactory<SerializedAvatarReportListView, UxmlTraits>
        {
        }
#endif
    }
}

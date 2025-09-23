using JetBrains.Annotations;
using Silksprite.AvatarRankerVista.API;

namespace Silksprite.AvatarRankerVista.VRChat.Criteria
{
    [PublicAPI]
    class VRChatPolyCount : ICriterionProvider<int>
    {
        public string Id => "net.kaikoga.arv.vrchat.polyCount";
        public string DisplayName => "Polygon Count";
        
        public int Measure(AvatarContext context)
        {
            return context.GetVRChatAvatarPerformanceStats().polyCount ?? -1;
        }
    }
}

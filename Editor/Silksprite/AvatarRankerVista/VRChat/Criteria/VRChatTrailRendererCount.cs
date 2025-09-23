using JetBrains.Annotations;
using Silksprite.AvatarRankerVista.API;

namespace Silksprite.AvatarRankerVista.VRChat.Criteria
{
    [PublicAPI]
    class VRChatTrailRendererCount : ICriterionProvider<int>
    {
        public string Id => "net.kaikoga.arv.vrchat.trailRendererCount";
        public string DisplayName => "TrailRenderer Count";
        
        public int Measure(AvatarContext context)
        {
            return context.GetVRChatAvatarPerformanceStats().trailRendererCount ?? -1;
        }
    }
}

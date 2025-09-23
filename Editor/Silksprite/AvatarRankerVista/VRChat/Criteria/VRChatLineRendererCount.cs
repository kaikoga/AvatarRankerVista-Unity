using JetBrains.Annotations;
using Silksprite.AvatarRankerVista.API;

namespace Silksprite.AvatarRankerVista.VRChat.Criteria
{
    [PublicAPI]
    class VRChatLineRendererCount : ICriterionProvider<int>
    {
        public string Id => "net.kaikoga.arv.vrchat.lineRendererCount";
        public string DisplayName => "LineRenderer Count";
        
        public int Measure(AvatarContext context)
        {
            return context.GetVRChatAvatarPerformanceStats().lineRendererCount ?? -1;
        }
    }
}

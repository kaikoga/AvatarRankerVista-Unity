using JetBrains.Annotations;
using Silksprite.AvatarRankerVista.API;

namespace Silksprite.AvatarRankerVista.VRChat.Criteria
{
    [PublicAPI]
    class VRChatConstraintDepth : ICriterionProvider<int>
    {
        public string Id => "net.kaikoga.arv.vrchat.constraintDepth";
        public string DisplayName => "Constraint Depth";
        
        public int Measure(AvatarContext context)
        {
            return context.GetVRChatAvatarPerformanceStats().constraintDepth ?? -1;
        }
    }
}

using JetBrains.Annotations;
using Silksprite.AvatarRankerVista.API;

namespace Silksprite.AvatarRankerVista.VRChat.Criteria
{
    [PublicAPI]
    class VRChatConstraintCount : ICriterionProvider<int>
    {
        public string Id => "net.kaikoga.arv.vrchat.constraintsCount";
        public string DisplayName => "Constraint Count";
        
        public int Measure(AvatarContext context)
        {
            return context.GetVRChatAvatarPerformanceStats().constraintsCount ?? -1;
        }
    }
}

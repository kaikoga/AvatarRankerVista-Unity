using JetBrains.Annotations;
using Silksprite.AvatarRankerVista.API;

namespace Silksprite.AvatarRankerVista.VRChat.Criteria
{
    [PublicAPI]
    class VRChatAnimatorCount : ICriterionProvider<int>
    {
        public string Id => "net.kaikoga.arv.vrchat.animatorCount";
        public string DisplayName => "Animator Count";
        
        public int Measure(AvatarContext context)
        {
            return context.GetVRChatAvatarPerformanceStats().animatorCount ?? -1;
        }
    }
}

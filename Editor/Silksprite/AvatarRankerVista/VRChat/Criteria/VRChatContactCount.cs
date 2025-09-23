using JetBrains.Annotations;
using Silksprite.AvatarRankerVista.API;

namespace Silksprite.AvatarRankerVista.VRChat.Criteria
{
    [PublicAPI]
    class VRChatContactCount : ICriterionProvider<int>
    {
        public string Id => "net.kaikoga.arv.vrchat.contactCount";
        public string DisplayName => "Contact Count";
        
        public int Measure(AvatarContext context)
        {
            return context.GetVRChatAvatarPerformanceStats().contactCount ?? -1;
        }
    }
}

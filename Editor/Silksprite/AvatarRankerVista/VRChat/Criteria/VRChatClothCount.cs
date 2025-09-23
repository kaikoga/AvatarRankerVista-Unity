using JetBrains.Annotations;
using Silksprite.AvatarRankerVista.API;

namespace Silksprite.AvatarRankerVista.VRChat.Criteria
{
    [PublicAPI]
    class VRChatClothCount : ICriterionProvider<int>
    {
        public string Id => "net.kaikoga.arv.vrchat.clothCount";
        public string DisplayName => "Cloth Count";
        
        public int Measure(AvatarContext context)
        {
            return context.GetVRChatAvatarPerformanceStats().clothCount ?? -1;
        }
    }
}

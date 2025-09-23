using JetBrains.Annotations;
using Silksprite.AvatarRankerVista.API;

namespace Silksprite.AvatarRankerVista.VRChat.Criteria
{
    [PublicAPI]
    class VRChatLightCount : ICriterionProvider<int>
    {
        public string Id => "net.kaikoga.arv.vrchat.lightCount";
        public string DisplayName => "Light Count";
        
        public int Measure(AvatarContext context)
        {
            return context.GetVRChatAvatarPerformanceStats().lightCount ?? -1;
        }
    }
}

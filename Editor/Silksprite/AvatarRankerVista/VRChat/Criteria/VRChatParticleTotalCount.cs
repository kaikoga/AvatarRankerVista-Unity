using JetBrains.Annotations;
using Silksprite.AvatarRankerVista.API;

namespace Silksprite.AvatarRankerVista.VRChat.Criteria
{
    [PublicAPI]
    class VRChatParticleTotalCount : ICriterionProvider<int>
    {
        public string Id => "net.kaikoga.arv.vrchat.particleTotalCount";
        public string DisplayName => "Particle Total Count";
        
        public int Measure(AvatarContext context)
        {
            return context.GetVRChatAvatarPerformanceStats().particleTotalCount ?? -1;
        }
    }
}

using JetBrains.Annotations;
using Silksprite.AvatarRankerVista.API;

namespace Silksprite.AvatarRankerVista.VRChat.Criteria
{
    [PublicAPI]
    class VRChatParticleSystemCount : ICriterionProvider<int>
    {
        public string Id => "net.kaikoga.arv.vrchat.particleSystemCount";
        public string DisplayName => "Particle System Count";
        
        public int Measure(AvatarContext context)
        {
            return context.GetVRChatAvatarPerformanceStats().particleSystemCount ?? -1;
        }
    }
}

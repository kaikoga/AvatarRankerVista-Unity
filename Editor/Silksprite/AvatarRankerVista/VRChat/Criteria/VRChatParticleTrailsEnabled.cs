using JetBrains.Annotations;
using Silksprite.AvatarRankerVista.API;

namespace Silksprite.AvatarRankerVista.VRChat.Criteria
{
    [PublicAPI]
    class VRChatParticleTrailsEnabled : ICriterionProvider<int>
    {
        public string Id => "net.kaikoga.arv.vrchat.particleTrailsEnabled";
        public string DisplayName => "Particle Trails Enabled";
        
        public int Measure(AvatarContext context)
        {
            return context.GetVRChatAvatarPerformanceStats().particleTrailsEnabled ?? true ? 1 : 0;
        }
    }
}

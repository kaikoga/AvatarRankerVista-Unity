using JetBrains.Annotations;
using Silksprite.AvatarRankerVista.API;
using Silksprite.AvatarRankerVista.Core;

namespace Silksprite.AvatarRankerVista.VRChat.Criteria
{
    [PublicAPI]
    class VRChatParticleTrailsEnabled : ICriterionProvider<NegativeFactor>
    {
        public string Id => "net.kaikoga.arv.vrchat.particleTrailsEnabled";
        public string DisplayName => "Particle Trails Enabled";
        
        public NegativeFactor Measure(AvatarContext context)
        {
            return context.GetVRChatAvatarPerformanceStats().particleTrailsEnabled ?? true ? NegativeFactor.True : NegativeFactor.False;
        }
    }
}

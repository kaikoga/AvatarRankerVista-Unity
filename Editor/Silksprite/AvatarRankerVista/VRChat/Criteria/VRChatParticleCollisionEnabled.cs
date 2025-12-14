using JetBrains.Annotations;
using Silksprite.AvatarRankerVista.API;
using Silksprite.AvatarRankerVista.Core;

namespace Silksprite.AvatarRankerVista.VRChat.Criteria
{
    [PublicAPI]
    class VRChatParticleCollisionEnabled : ICriterionProvider<NegativeFactor>
    {
        public string Id => "net.kaikoga.arv.vrchat.particleCollisionEnabled";
        public string DisplayName => "Particle Collision Enabled";
        
        public NegativeFactor Measure(AvatarContext context)
        {
            return context.GetVRChatAvatarPerformanceStats().particleCollisionEnabled ?? true ? NegativeFactor.True : NegativeFactor.False;
        }
    }
}

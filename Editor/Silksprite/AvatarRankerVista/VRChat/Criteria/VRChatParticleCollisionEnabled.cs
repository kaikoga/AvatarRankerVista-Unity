using JetBrains.Annotations;
using Silksprite.AvatarRankerVista.API;

namespace Silksprite.AvatarRankerVista.VRChat.Criteria
{
    [PublicAPI]
    class VRChatParticleCollisionEnabled : ICriterionProvider<int>
    {
        public string Id => "net.kaikoga.arv.vrchat.particleCollisionEnabled";
        public string DisplayName => "Particle Collision Enabled";
        
        public int Measure(AvatarContext context)
        {
            return context.GetVRChatAvatarPerformanceStats().particleCollisionEnabled ?? true ? 1 : 0;
        }
    }
}

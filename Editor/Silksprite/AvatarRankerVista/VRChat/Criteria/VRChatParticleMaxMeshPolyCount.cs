using JetBrains.Annotations;
using Silksprite.AvatarRankerVista.API;

namespace Silksprite.AvatarRankerVista.VRChat.Criteria
{
    [PublicAPI]
    class VRChatParticleMaxMeshPolyCount : ICriterionProvider<int>
    {
        public string Id => "net.kaikoga.arv.vrchat.particleMaxMeshPolyCount";
        public string DisplayName => "Particle Max Mesh Poly Count";
        
        public int Measure(AvatarContext context)
        {
            return context.GetVRChatAvatarPerformanceStats().particleMaxMeshPolyCount ?? -1;
        }
    }
}

using JetBrains.Annotations;
using Silksprite.AvatarRankerVista.API;

namespace Silksprite.AvatarRankerVista.VRChat.Criteria
{
    [PublicAPI]
    class VRChatPhysBoneColliderCount : ICriterionProvider<int>
    {
        public string Id => "net.kaikoga.arv.vrchat.physBone.colliderCount";
        public string DisplayName => "PhysBone Collider Count";
        
        public int Measure(AvatarContext context)
        {
            return context.GetVRChatAvatarPerformanceStats().physBone?.colliderCount ?? -1;
        }
    }
}

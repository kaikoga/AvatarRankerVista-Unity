using JetBrains.Annotations;
using Silksprite.AvatarRankerVista.API;

namespace Silksprite.AvatarRankerVista.VRChat.Criteria
{
    [PublicAPI]
    class VRChatPhysBoneCollisionCheckCount : ICriterionProvider<int>
    {
        public string Id => "net.kaikoga.arv.vrchat.physBone.collisionCheckCount";
        public string DisplayName => "PhysBone Collision Check Count";
        
        public int Measure(AvatarContext context)
        {
            return context.GetVRChatAvatarPerformanceStats().physBone?.collisionCheckCount ?? -1;
        }
    }
}

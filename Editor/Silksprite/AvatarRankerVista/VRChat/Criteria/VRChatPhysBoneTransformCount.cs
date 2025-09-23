using JetBrains.Annotations;
using Silksprite.AvatarRankerVista.API;

namespace Silksprite.AvatarRankerVista.VRChat.Criteria
{
    [PublicAPI]
    class VRChatPhysBoneTransformCount : ICriterionProvider<int>
    {
        public string Id => "net.kaikoga.arv.vrchat.physBone.transformCount";
        public string DisplayName => "PhysBone Transform Count";
        
        public int Measure(AvatarContext context)
        {
            return context.GetVRChatAvatarPerformanceStats().physBone?.transformCount ?? -1;
        }
    }
}

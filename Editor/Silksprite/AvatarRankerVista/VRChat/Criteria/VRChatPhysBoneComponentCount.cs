using JetBrains.Annotations;
using Silksprite.AvatarRankerVista.API;

namespace Silksprite.AvatarRankerVista.VRChat.Criteria
{
    [PublicAPI]
    class VRChatPhysBoneComponentCount : ICriterionProvider<int>
    {
        public string Id => "net.kaikoga.arv.vrchat.physBone.componentCount";
        public string DisplayName => "PhysBone Component Count";
        
        public int Measure(AvatarContext context)
        {
            return context.GetVRChatAvatarPerformanceStats().physBone?.componentCount ?? -1;
        }
    }
}

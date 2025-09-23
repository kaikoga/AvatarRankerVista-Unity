using JetBrains.Annotations;
using Silksprite.AvatarRankerVista.API;

namespace Silksprite.AvatarRankerVista.VRChat.Criteria
{
    [PublicAPI]
    class VRChatMaterialCount : ICriterionProvider<int>
    {
        public string Id => "net.kaikoga.arv.vrchat.materialCount";
        public string DisplayName => "Material Slot Count";
        
        public int Measure(AvatarContext context)
        {
            return context.GetVRChatAvatarPerformanceStats().materialCount ?? -1;
        }
    }
}

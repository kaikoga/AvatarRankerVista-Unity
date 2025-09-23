using JetBrains.Annotations;
using Silksprite.AvatarRankerVista.API;

namespace Silksprite.AvatarRankerVista.VRChat.Criteria
{
    [PublicAPI]
    class VRChatClothMaxVertices : ICriterionProvider<int>
    {
        public string Id => "net.kaikoga.arv.vrchat.clothMaxVertices";
        public string DisplayName => "Cloth Total Vertices";
        
        public int Measure(AvatarContext context)
        {
            return context.GetVRChatAvatarPerformanceStats().clothMaxVertices ?? -1;
        }
    }
}

using JetBrains.Annotations;
using Silksprite.AvatarRankerVista.API;

namespace Silksprite.AvatarRankerVista.VRChat.Criteria
{
    [PublicAPI]
    class VRChatSkinnedMeshCount : ICriterionProvider<int>
    {
        public string Id => "net.kaikoga.arv.vrchat.skinnedMeshCount";
        public string DisplayName => "SkinnedMesh Count";
        
        public int Measure(AvatarContext context)
        {
            return context.GetVRChatAvatarPerformanceStats().skinnedMeshCount ?? -1;
        }
    }
}

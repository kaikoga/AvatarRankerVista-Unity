using JetBrains.Annotations;
using Silksprite.AvatarRankerVista.API;

namespace Silksprite.AvatarRankerVista.VRChat.Criteria
{
    [PublicAPI]
    class VRChatBoneCount : ICriterionProvider<int>
    {
        public string Id => "net.kaikoga.arv.vrchat.boneCount";
        public string DisplayName => "Animator Bone Count";
        
        public int Measure(AvatarContext context)
        {
            return context.GetVRChatAvatarPerformanceStats().boneCount ?? -1;
        }
    }
}

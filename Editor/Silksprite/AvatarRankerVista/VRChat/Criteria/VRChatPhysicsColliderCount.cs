using JetBrains.Annotations;
using Silksprite.AvatarRankerVista.API;

namespace Silksprite.AvatarRankerVista.VRChat.Criteria
{
    [PublicAPI]
    class VRChatPhysicsColliderCount : ICriterionProvider<int>
    {
        public string Id => "net.kaikoga.arv.vrchat.physicsColliderCount";
        public string DisplayName => "Physics Collider Count";
        
        public int Measure(AvatarContext context)
        {
            return context.GetVRChatAvatarPerformanceStats().physicsColliderCount ?? -1;
        }
    }
}

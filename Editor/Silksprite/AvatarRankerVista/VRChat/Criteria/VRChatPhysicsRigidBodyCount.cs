using JetBrains.Annotations;
using Silksprite.AvatarRankerVista.API;

namespace Silksprite.AvatarRankerVista.VRChat.Criteria
{
    [PublicAPI]
    class VRChatPhysicsRigidBodyCount : ICriterionProvider<int>
    {
        public string Id => "net.kaikoga.arv.vrchat.physicsRigidbodyCount";
        public string DisplayName => "Physics RigidBody Count";
        
        public int Measure(AvatarContext context)
        {
            return context.GetVRChatAvatarPerformanceStats().physicsRigidbodyCount ?? -1;
        }
    }
}

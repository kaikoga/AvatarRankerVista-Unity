using JetBrains.Annotations;
using Silksprite.AvatarRankerVista.API;
using UnityEngine;

namespace Silksprite.AvatarRankerVista.VRChat.Criteria
{
    [PublicAPI]
    class VRChatAABBSize : ICriterionProvider<Vector3>
    {
        public string Id => "net.kaikoga.arv.vrchat.aabb";
        public string DisplayName => "Bounds Size";
        
        public Vector3 Measure(AvatarContext context)
        {
            return context.GetVRChatAvatarPerformanceStats().aabb?.size ?? Vector3.zero;
        }
    }
}

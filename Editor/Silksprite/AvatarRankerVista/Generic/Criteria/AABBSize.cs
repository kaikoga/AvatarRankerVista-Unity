using JetBrains.Annotations;
using Silksprite.AvatarRankerVista.API;
using UnityEngine;

namespace Silksprite.AvatarRankerVista.Generic.Criteria
{
    [PublicAPI]
    public class AABBSize : ICriterionProvider<Vector3>
    {
        public string Id => "net.kaikoga.arv.size.aabb";
        public string DisplayName => "AABB Size";
        
        public Vector3 Measure(AvatarContext context)
        {
            return Vector3.zero;
        }
    }
}

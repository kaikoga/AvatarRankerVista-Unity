using System.Linq;
using JetBrains.Annotations;
using Silksprite.AvatarRankerVista.API;
using UnityEngine;

namespace Silksprite.AvatarRankerVista.Generic.Criteria
{
    [PublicAPI]
    public class PolygonCount : ICriterionProvider<int>
    {
        public string Id => "net.kaikoga.arv.count.renderer.polygon";
        public string DisplayName => "Polygon Count";
        
        public int Measure(AvatarContext context)
        {
            return context.GetComponentsInChildren<MeshFilter>().Sum(meshFilter => meshFilter.sharedMesh.triangles.Length / 3)
                   + context.GetComponentsInChildren<SkinnedMeshRenderer>().Sum(smr => smr.sharedMesh.triangles.Length / 3);
        }
    }
}

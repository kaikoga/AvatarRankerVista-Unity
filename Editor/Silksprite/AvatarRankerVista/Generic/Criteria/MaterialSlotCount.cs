using System.Linq;
using JetBrains.Annotations;
using Silksprite.AvatarRankerVista.API;
using UnityEngine;

namespace Silksprite.AvatarRankerVista.Generic.Criteria
{
    [PublicAPI]
    public class MaterialSlotCount : ICriterionProvider<int>
    {
        public string Id => "net.kaikoga.arv.count.renderer.material";
        public string DisplayName => "Material Slot Count";
        
        public int Measure(AvatarContext context)
        {
            return context.GetComponentsInChildren<Renderer>().Sum(renderer => renderer.sharedMaterials.Length);
        }
    }
}

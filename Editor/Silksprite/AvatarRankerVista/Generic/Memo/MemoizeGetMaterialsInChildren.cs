using System.Linq;
using JetBrains.Annotations;
using Silksprite.AvatarRankerVista.API;
using Silksprite.AvatarRankerVista.Generic.Memo;
using UnityEngine;

namespace Silksprite.AvatarRankerVista.Generic.Memo
{
    [PublicAPI]
    public class MemoizeGetMaterialsInChildren : IMemoProvider<Material[]>
    {
        public Material[] Resolve(AvatarContext context)
        {
            return context.GetComponentsInChildren<Renderer>()
                .SelectMany(renderer => renderer.sharedMaterials)
                .Where(material => material)
                .Distinct()
                .ToArray();
        }
    }
}

namespace Silksprite.AvatarRankerVista.API
{
    public static class GetMaterialsInChildrenExtension
    {
        public static Material[] GetMaterialsInChildren(this AvatarContext context)
        {
            return context.Resolve<Material[], MemoizeGetMaterialsInChildren>();
        }
    }
}

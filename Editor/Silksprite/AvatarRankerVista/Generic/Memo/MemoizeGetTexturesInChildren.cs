using System.Linq;
using JetBrains.Annotations;
using Silksprite.AvatarRankerVista.API;
using Silksprite.AvatarRankerVista.Generic.Memo;
using UnityEngine;

namespace Silksprite.AvatarRankerVista.Generic.Memo
{
    [PublicAPI]
    public class MemoizeGetTexturesInChildren : IMemoProvider<Texture[]>
    {
        public Texture[] Resolve(AvatarContext context)
        {
            return context.GetMaterialsInChildren()
                .SelectMany(material => material.GetTexturePropertyNameIDs().Select(material.GetTexture))
                .Where(texture => texture)
                .Distinct()
                .ToArray();
        }
    }
}

namespace Silksprite.AvatarRankerVista.API
{
    public static class GetTexturesInChildrenExtension
    {
        public static Texture[] GetTexturesInChildren(this AvatarContext context)
        {
            return context.Resolve<Texture[], MemoizeGetTexturesInChildren>();
        }
    }
}

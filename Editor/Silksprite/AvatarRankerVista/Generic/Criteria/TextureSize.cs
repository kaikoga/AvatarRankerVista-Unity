using System.Linq;
using JetBrains.Annotations;
using Silksprite.AvatarRankerVista.API;
using UnityEngine;

namespace Silksprite.AvatarRankerVista.Generic.Criteria
{
    [PublicAPI]
    public class TextureSize : ICriterionProvider<int>
    {
        public string Id => "net.kaikoga.arv.count.texture.size";
        public string DisplayName => "Texture Size";
        
        public int Measure(AvatarContext context)
        {
            return context.GetTexturesInChildren().Select(texture => Mathf.Max(texture.width, texture.height)).Concat(new [] { 0 }).Max();
        }
    }
}

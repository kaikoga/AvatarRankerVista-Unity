using System.Linq;
using JetBrains.Annotations;
using Silksprite.AvatarRankerVista.API;

namespace Silksprite.AvatarRankerVista.Generic.Criteria
{
    [PublicAPI]
    public class TexturePixelCount : ICriterionProvider<int>
    {
        public string Id => "net.kaikoga.arv.count.texture.pixel";
        public string DisplayName => "Texture Pixel Count";
        
        public int Measure(AvatarContext context)
        {
            return context.GetTexturesInChildren().Sum(texture => texture.width * texture.height);
        }
    }
}

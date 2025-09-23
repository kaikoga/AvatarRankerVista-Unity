using JetBrains.Annotations;
using Silksprite.AvatarRankerVista.API;

namespace Silksprite.AvatarRankerVista.Generic.Criteria
{
    [PublicAPI]
    public class MaterialCount : ICriterionProvider<int>
    {
        public string Id => "net.kaikoga.arv.count.material.distinct";
        public string DisplayName => "Material Count";
        
        public int Measure(AvatarContext context)
        {
            return context.GetMaterialsInChildren().Length;
        }
    }
}

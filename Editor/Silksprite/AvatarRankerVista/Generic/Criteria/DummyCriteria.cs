using JetBrains.Annotations;
using Silksprite.AvatarRankerVista.API;

namespace Silksprite.AvatarRankerVista.Generic.Criteria
{
    [PublicAPI]
    public class DummyCriteria<T> : ICriterionProvider<T>
    {
        public string Id => "net.kaikoga.arv.dummy";
        public string DisplayName => "Dummy";
        
        public T Measure(AvatarContext context)
        {
            return default;
        }
    }
}

using JetBrains.Annotations;
using Silksprite.AvatarRankerVista.API;

namespace Silksprite.AvatarRankerVista.Generic.Criteria
{
    [PublicAPI]
    public class ComponentCount<T> : ICriterionProvider<int>
    {
        public string Id => $"net.kaikoga.arv.count.component.{typeof(T).FullName}";
        public string DisplayName => $"{typeof(T).Name} Count";
        
        public int Measure(AvatarContext context)
        {
            return context.GetComponentsInChildren<T>().Length;
        }
    }
}

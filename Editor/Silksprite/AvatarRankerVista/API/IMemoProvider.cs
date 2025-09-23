using JetBrains.Annotations;

namespace Silksprite.AvatarRankerVista.API
{
    [PublicAPI]
    public interface IMemoProvider<out T>
    {
        public T Resolve(AvatarContext context);
    }
}

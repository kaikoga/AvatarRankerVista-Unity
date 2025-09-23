using JetBrains.Annotations;
using Silksprite.AvatarRankerVista.API;
using Silksprite.AvatarRankerVista.Generic.Memo;

namespace Silksprite.AvatarRankerVista.Generic.Memo
{
    [PublicAPI]
    public class MemoizeGetComponentsInChildren<T> : IMemoProvider<T[]>
    {
        public T[] Resolve(AvatarContext context)
        {
            return context.AvatarRootObject.GetComponentsInChildren<T>();
        }
    }
}

namespace Silksprite.AvatarRankerVista.API
{
    public static class GetComponentsInChildrenCacheExtension
    {
        public static T[] GetComponentsInChildren<T>(this AvatarContext context)
        {
            return context.Resolve<T[], MemoizeGetComponentsInChildren<T>>();
        }
    }
}

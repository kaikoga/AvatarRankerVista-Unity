using System;
using System.Collections.Generic;
using JetBrains.Annotations;
using UnityEngine;

namespace Silksprite.AvatarRankerVista.API
{
    [PublicAPI]
    public class AvatarContext
    {
        public readonly GameObject AvatarRootObject;
        readonly Dictionary<Type, object> _cache = new Dictionary<Type, object>();

        public readonly string AvatarPath;
        public readonly string AvatarSceneName;

        public AvatarContext(GameObject avatarRootObject)
        {
            AvatarRootObject = avatarRootObject;
            var avatarPath = AvatarRootObject.name;
            if (avatarPath.EndsWith("(Clone)"))
            {
                avatarPath = avatarPath.Substring(0, avatarPath.Length - "(Clone)".Length);
            }
            AvatarPath = avatarPath;
            AvatarSceneName = avatarRootObject.scene.name;
        }

        public T Resolve<T, TCache>()
        where TCache : IMemoProvider<T>, new()
        {
            if (_cache.TryGetValue(typeof(TCache), out var existing))
            {
                return (T) existing;
            }
            var value = new TCache().Resolve(this);
            _cache.Add(typeof(TCache), value);
            return value;
        }
    }
}

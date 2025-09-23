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

        public readonly string AvatarName;
        public readonly string AvatarSceneName;

        public AvatarContext(GameObject avatarRootObject)
        {
            AvatarRootObject = avatarRootObject;
            var avatarName = AvatarRootObject.name;
            if (avatarName.EndsWith("(Clone)"))
            {
                avatarName = avatarName.Substring(0, avatarName.Length - "(Clone)".Length);
            }
            AvatarName = avatarName;
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

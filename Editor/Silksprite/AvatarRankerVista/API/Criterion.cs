using System;
using System.Collections.Generic;
using JetBrains.Annotations;
using UnityEngine;

namespace Silksprite.AvatarRankerVista.API
{
    [PublicAPI]
    public abstract class Criterion
    {
        public abstract string Id { get; }
        public abstract string DisplayName { get; }
        public abstract Type Type { get; }

        public abstract Criterion Measure(AvatarContext context);

        public abstract bool Fulfills(Criterion defined);
        
        public abstract string ValueString { get; }
    }

    [PublicAPI]
    public class Criterion<T, TProvider> : Criterion
    where TProvider : class, ICriterionProvider<T>
    {
        readonly TProvider _provider = CriterionProviderRepository.Instance.OfType<TProvider>();

        public override string Id => _provider.Id;
        public override string DisplayName => _provider.DisplayName;
        public override Type Type => typeof(TProvider);
        readonly T _value;

        public Criterion(T value)
        {
            _value = value;
        }

        public override Criterion Measure(AvatarContext context)
        {
            return new Criterion<T, TProvider>(_provider.Measure(context));
        }

        public override bool Fulfills(Criterion defined)
        {
            return defined is Criterion<T, TProvider> levelCriterion && (v: _value, lv: levelCriterion._value) switch
            {
                (int v, int lv) => v <= lv,
                (float v, float lv) => v <= lv,
                (Vector3 v, Vector3 lv) => v.x <= lv.x && v.y <= lv.y && v.z <= lv.z,
                _ => Comparer<T>.Default.Compare(_value, levelCriterion._value) <= 0,
            };
        }

        public override string ValueString => _value.ToString();

        public override string ToString()
        {
            return $"{_provider.DisplayName}: {_value}";
        }
    }
}

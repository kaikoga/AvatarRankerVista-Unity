using System;
using System.Collections.Generic;
using Silksprite.AvatarRankerVista.API;

namespace Silksprite.AvatarRankerVista.Core
{
    public class CriterionSet
    {
        readonly Dictionary<Type, Criterion> _criteria = new Dictionary<Type, Criterion>();

        void Add(Criterion criterion)
        {
            _criteria.Add(criterion.Type, criterion);
        }

        bool TryGetValue(Criterion criterion, out Criterion value)
        {
            return _criteria.TryGetValue(criterion.Type, out value);
        }

        public Criterion Measure(Criterion criterion, AvatarContext context)
        {
            if (TryGetValue(criterion, out var existing))
            {
                return existing;
            }
            var newValue = criterion.Measure(context);
            Add(newValue);
            return newValue;
        }
    }
}

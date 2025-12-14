using System.Collections.Generic;
using System.Linq;
using JetBrains.Annotations;
using UnityEngine;

namespace Silksprite.AvatarRankerVista.API
{
    [PublicAPI]
    public class RegulationLevel
    {
        public readonly string Id;
        public readonly string DisplayName;
        public readonly Color Color;
        public readonly IEnumerable<Criterion> Criteria;

        RegulationLevel(string id, string displayName, Color color, IEnumerable<Criterion> criteria)
        {
            Id = id;
            DisplayName = displayName;
            Color = color;
            Criteria = criteria.ToArray();
        }

        public override string ToString() => DisplayName;

        public class Builder
        {
            public string Id;
            public string DisplayName;
            public Color Color;
            public IEnumerable<Criterion> Criteria;

            public RegulationLevel Build()
            {
                return new RegulationLevel(Id, DisplayName, Color, Criteria);
            }
        }
    }
}

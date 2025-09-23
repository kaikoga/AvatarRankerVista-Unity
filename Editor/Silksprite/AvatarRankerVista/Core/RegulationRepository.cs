using System;
using System.Collections.Generic;
using System.Linq;
using Silksprite.AvatarRankerVista.API;
using Silksprite.AvatarRankerVista.API.Attributes;
using UnityEditor;

namespace Silksprite.AvatarRankerVista.Core
{
    public class RegulationRepository
    {
        public static readonly RegulationRepository Instance = new RegulationRepository();

        readonly Regulation[] _regulations;
        
        RegulationRepository()
        {
            _regulations = CollectRegulations();
        }

        public Regulation GetRegulation(string id)
        {
            return _regulations.FirstOrDefault(reg => reg.Id == id);
        }

        public IEnumerable<Regulation> AllRegulations()
        {
            return _regulations;
        }

        static Regulation[] CollectRegulations()
        {
            return TypeCache.GetTypesWithAttribute<RegulationProviderAttribute>()
                .Select(regulationType => regulationType.GetConstructor(Array.Empty<Type>())?.Invoke(null))
                .OfType<IRegulationProvider>()
                .Select(provider => new Regulation(provider))
                .OrderBy(regulation => regulation.Priority)
                .ToArray();
        }
    }
}

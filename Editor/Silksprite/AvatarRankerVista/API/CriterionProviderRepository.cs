using System;
using System.Collections.Generic;

namespace Silksprite.AvatarRankerVista.API
{
    class CriterionProviderRepository
    {
        public static readonly CriterionProviderRepository Instance = new CriterionProviderRepository();
        readonly Dictionary<Type, object> _providers = new Dictionary<Type, object>();

        CriterionProviderRepository()
        {
        }

        public TProvider OfType<TProvider>()
            where TProvider : class, ICriterionProvider
        {
            if (_providers.TryGetValue(typeof(TProvider), out var provider)) return provider as TProvider;
            var tProvider = Activator.CreateInstance<TProvider>();
            _providers.Add(typeof(TProvider), tProvider);
            return tProvider;
        }
    }
}

using System.Collections.Generic;
using JetBrains.Annotations;

namespace Silksprite.AvatarRankerVista.API
{
    [PublicAPI]
    public interface IRegulationProvider
    {
        string Id { get; }
        string DisplayName { get; }
        int Priority { get; }

        bool IsMatchingPlatform(AvatarContext avatarContext);

        IEnumerable<RegulationLevel> DefineLevels();
    }
}

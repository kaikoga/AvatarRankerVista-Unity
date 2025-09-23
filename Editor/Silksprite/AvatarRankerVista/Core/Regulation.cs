using System.Linq;
using Silksprite.AvatarRankerVista.API;

namespace Silksprite.AvatarRankerVista.Core
{
    public class Regulation
    {
        readonly IRegulationProvider _regulation;

        public string Id => _regulation.Id;
        public string DisplayName => _regulation.DisplayName;
        public int Priority => _regulation.Priority;

        public bool IsMatchingPlatform(AvatarContext avatarContext) => _regulation.IsMatchingPlatform(avatarContext);

        public readonly RegulationLevel[] Levels;

        public Regulation(IRegulationProvider regulation)
        {
            _regulation = regulation;
            Levels = _regulation.DefineLevels().ToArray();
        }
    }
}

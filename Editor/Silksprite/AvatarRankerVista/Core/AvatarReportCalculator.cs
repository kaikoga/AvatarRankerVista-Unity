using System.Collections.Generic;
using System.Linq;
using Silksprite.AvatarRankerVista.API;

namespace Silksprite.AvatarRankerVista.Core
{
    public class AvatarReportCalculator
    {
        readonly IEnumerable<Regulation> _regulations;

        public AvatarReportCalculator(IEnumerable<Regulation> regulations)
        {
            _regulations = regulations;
        }

        public IEnumerable<AvatarReport> Measure(AvatarContext context)
        {
            var criterionSet = new CriterionSet();

            return _regulations.Select(regulation =>
            {
                var avatarReport = new AvatarReport(context, regulation);

                var levels = regulation.Levels.ToArray();
                foreach (var level in levels)
                {
                    foreach (var criterionDef in level.Criteria)
                    {
                        var measured = criterionSet.Measure(criterionDef, context);
                        avatarReport.JudgeLevel(measured, criterionDef, level);
                    }
                }
                avatarReport.DecideDefaultLevel(levels.Last());
                return avatarReport;
            });
        }
    }
}

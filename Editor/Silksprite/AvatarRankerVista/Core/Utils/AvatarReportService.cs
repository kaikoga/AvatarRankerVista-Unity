using System.Linq;
using Silksprite.AvatarRankerVista.API;
using Silksprite.AvatarRankerVista.Core.Serialized;
using UnityEngine;

namespace Silksprite.AvatarRankerVista.Core.Utils
{
    public static class AvatarReportService
    {
        public static void MeasureAll(GameObject avatarRootObject, bool isBuild)
        {
            if (!AvatarRankerSettingsRepository.instance.MeasureOnBuild)
            {
                return;
            }
            var regulations = RegulationRepository.Instance.AllRegulations()
                .Where(regulation => AvatarRankerSettingsRepository.instance.GetRegulationEnabled(regulation));
            var avatarReports = new AvatarReportCalculator(regulations)
                .Measure(new AvatarContext(avatarRootObject))
                .Select(report =>
                {
                    var origin = (isBuild, report.IsMatchingPlatform) switch
                    {
                        (false, _) => AvatarReportOrigin.EditMode,
                        (true, false) => AvatarReportOrigin.ReferenceBuild,
                        (true, true) => AvatarReportOrigin.ActualBuild
                    };
                    return report.Export(origin);
                });
            SerializedAvatarReportRepository.instance.AddRange(avatarReports);
        }
    }
}

using System.Linq;
using Ablet.Models.Serialized;
using Ablet.Repositories;
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
                }).ToArray();

            foreach (var avatarReport in avatarReports)
            {
                BuildReportRepository.Instance.Add(new SerializedBuildReport(
                    new SerializedEntrypointReference(
                        avatarReport.avatarReference.scenePath,
                        avatarReport.avatarReference.path
                    ),
                    "net.kaikoga.arv",
                    avatarReport
                ));
            }
        }
    }
}

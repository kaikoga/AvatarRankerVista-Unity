using System.Linq;
using Silksprite.AvatarRankerVista.API;
using Silksprite.AvatarRankerVista.Window;

namespace Silksprite.AvatarRankerVista.Core.Serialized
{
    public static class AvatarReportSerializer
    {
        public static SerializedAvatarReport Export(this AvatarReport avatarReport, AvatarReportOrigin origin)
        {
            return new SerializedAvatarReport
            {
                avatarName = new SerializedAvatarName
                {
                    sceneName = avatarReport.AvatarSceneName,
                    name = avatarReport.AvatarName,
                },
                origin = origin,
                regulation = avatarReport.Regulation.Export(),
                overallLevel = avatarReport.OverallLevel.Export(),
                result = avatarReport.Regulation.Levels
                    .Reverse()
                    .SelectMany(level => avatarReport.Entries.Where(entry => level.Id == entry.Level.Id))
                    .Select(entry => entry.Export())
                    .ToArray()

            };
        }

        static SerializedRegulationRef Export(this Regulation regulation)
        {
            return new SerializedRegulationRef
            {
                id = regulation.Id,
                displayName = regulation.DisplayName
            };
        }

        static SerializedRegulationLevelRef Export(this RegulationLevel level)
        {
            return new SerializedRegulationLevelRef
            {
                id = level.Id,
                displayName = level.DisplayName
            };
        }

        static SerializedAvatarReportEntry Export(this AvatarReport.AvatarReportEntry entry)
        {
            return new SerializedAvatarReportEntry
            {
                criterion = entry.Criterion.Export(),
                level = entry.Level.Export(),
                recommendedValue = entry.RecommendedValue?.ValueString ?? "",
                recommendedLevel = entry.RecommendedLevel?.Export() ?? new SerializedRegulationLevelRef()
            };
        }

        static SerializedCriterionRef Export(this Criterion criterion)
        {
            return new SerializedCriterionRef
            {
                id = criterion.Id,
                displayName = criterion.DisplayName,
                value = criterion.ValueString
            };
        }
    }
}

using System;
using System.Collections.Generic;
using Silksprite.AvatarRankerVista.API;

namespace Silksprite.AvatarRankerVista.Core
{
    public class AvatarReport
    {
        public readonly string AvatarName;
        public readonly string AvatarSceneName;
        public readonly Regulation Regulation;
        public readonly bool IsMatchingPlatform;
        public RegulationLevel OverallLevel { get; private set; }

        public IEnumerable<AvatarReportEntry> Entries => _entries.Values;

        readonly Dictionary<Type, AvatarReportEntry> _entries = new Dictionary<Type, AvatarReportEntry>();
        readonly Dictionary<Type, (Criterion criterion, RegulationLevel level)> _recommended = new Dictionary<Type, (Criterion, RegulationLevel)>();
        readonly Dictionary<Type, Criterion> _undecidedCriteria = new Dictionary<Type, Criterion>();

        public AvatarReport(AvatarContext avatarContext, Regulation regulation)
        {
            AvatarName = avatarContext.AvatarName;
            AvatarSceneName = avatarContext.AvatarSceneName;
            Regulation = regulation;
            IsMatchingPlatform = regulation.IsMatchingPlatform(avatarContext);
        }

        public void JudgeLevel(Criterion criterion, Criterion levelCriterion, RegulationLevel regulationLevel)
        {
            if (criterion.Fulfills(levelCriterion))
            {
                DecideLevel(criterion, regulationLevel);
            }
            else
            {
                _recommended[criterion.Type] = (levelCriterion, regulationLevel);
                _undecidedCriteria.TryAdd(criterion.Type, criterion);
            }
        }

        public void DecideDefaultLevel(RegulationLevel regulationLevel)
        {
            foreach (var criterion in _undecidedCriteria.Values)
            {
                DecideLevel(criterion, regulationLevel);
            }
            _undecidedCriteria.Clear();
        }

        void DecideLevel(Criterion criterion, RegulationLevel regulationLevel)
        {
            if (_entries.ContainsKey(criterion.Type))
            {
                return;
            }
            var recommended = _recommended.GetValueOrDefault(criterion.Type);
            _entries.Add(
                criterion.Type,
                new AvatarReportEntry(
                    criterion,
                    regulationLevel,
                    recommended.criterion,
                    recommended.level));
            OverallLevel = regulationLevel;
        }

        public override string ToString()
        {
            return  $"{Regulation.DisplayName}\n" +
                   $"Overall level: {OverallLevel.DisplayName}\n" + 
                   string.Join("\n", _entries.Values);
        }
        
        public class AvatarReportEntry
        {
            public readonly Criterion Criterion;
            public readonly RegulationLevel Level;
            public readonly Criterion RecommendedValue;
            public readonly RegulationLevel RecommendedLevel;
            
            public AvatarReportEntry(Criterion criterion, RegulationLevel level, Criterion recommendedValue, RegulationLevel recommendedLevel)
            {
                Criterion = criterion;
                Level = level;
                RecommendedValue = recommendedValue;
                RecommendedLevel = recommendedLevel;
            }

            public override string ToString()
            {
                return RecommendedValue != null ? $"{Criterion} {Level} ({RecommendedValue.ValueString} for {RecommendedLevel})" : $"{Criterion} {Level}";
            }
        }
    }
}

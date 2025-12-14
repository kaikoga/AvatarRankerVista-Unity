using System.Collections.Generic;
using Silksprite.AvatarRankerVista.API;
using Silksprite.AvatarRankerVista.API.Attributes;
using UnityEngine;
using VRC.SDK3.Avatars.Components;
using VRC.SDKBase.Validation.Performance.Stats;

namespace Silksprite.AvatarRankerVista.VRChat
{
    abstract class VRChatRegulationBase : IRegulationProvider
    {
        protected static readonly AvatarPerformanceStatsLevelSet Windows = Resources.Load<AvatarPerformanceStatsLevelSet>("Validation/Performance/StatsLevels/Windows/AvatarPerformanceStatLevels_Windows");
        protected static readonly AvatarPerformanceStatsLevelSet Mobile = Resources.Load<AvatarPerformanceStatsLevelSet>("Validation/Performance/StatsLevels/Quest/AvatarPerformanceStatLevels_Quest");
        
        public abstract string Id { get; }
        public abstract string DisplayName { get; }
        public abstract int Priority { get; }

        protected abstract VRChatCriteriaBinding Binding();
        protected abstract AvatarPerformanceStatsLevelSet LevelSet();

        public abstract bool IsMatchingPlatform(AvatarContext avatarContext);

        static Color ToColor(uint argb)
        {
            var a = (byte)((argb & 0xff000000) >> 24);
            var r = (byte)((argb & 0x00ff0000) >> 16);
            var g = (byte)((argb & 0x0000ff00) >> 8);
            var b = (byte)(argb & 0x000000ff);
            return new Color32(r, g, b, a);
        }

        public IEnumerable<RegulationLevel> DefineLevels()
        {
            yield return new RegulationLevel.Builder
            {
                Id = "excellent",
                DisplayName = "Excellent",
                Color = ToColor(0xff90ee90),
                Criteria = Excellent()
            }.Build();
            
            yield return new RegulationLevel.Builder
            {
                Id = "good",
                DisplayName = "Good",
                Color = ToColor(0xff008000),
                Criteria = Good()
            }.Build();
            
            yield return new RegulationLevel.Builder
            {
                Id = "medium",
                DisplayName = "Medium",
                Color = ToColor(0xffdaa520),
                Criteria = Medium()
            }.Build();
            
            yield return new RegulationLevel.Builder
            {
                Id = "poor",
                DisplayName = "Poor",
                Color = ToColor(0xffff4500),
                Criteria = Poor()
            }.Build();
            
            yield return new RegulationLevel.Builder
            {
                Id = "veryPoor",
                DisplayName = "VeryPoor",
                Color = ToColor(0xff8b0000),
                Criteria = VeryPoor()
            }.Build();
        }

        IEnumerable<Criterion> Excellent() => Binding().Build(LevelSet().excellent);
        IEnumerable<Criterion> Good() => Binding().Build(LevelSet().good);
        IEnumerable<Criterion> Medium() => Binding().Build(LevelSet().medium);
        IEnumerable<Criterion> Poor() => Binding().Build(LevelSet().poor);

        static IEnumerable<Criterion> VeryPoor()
        {
            yield break;
        }
    }

    [RegulationProvider]
    class VRChatRegulation : VRChatRegulationBase
    {
        public override string Id => "net.kaikoga.arv.vrchat.avatar3";
        public override string DisplayName => "VRChat";
        public override int Priority => 0;

        protected override VRChatCriteriaBinding Binding() => new VRChatCriteria();
        protected override AvatarPerformanceStatsLevelSet LevelSet() => Windows;
        
        public override bool IsMatchingPlatform(AvatarContext avatarContext)
        {
#if UNITY_STANDALONE_WIN
            return avatarContext.AvatarRootObject.GetComponent<VRCAvatarDescriptor>();
#else
            return false;
#endif
        }
    }

    [RegulationProvider]
    class VRChatMobileRegulation : VRChatRegulationBase
    {
        public override string Id => "net.kaikoga.arv.vrchat.avatar3.mobile";
        public override string DisplayName => "VRChat Mobile";
        public override int Priority => 1;

        protected override VRChatCriteriaBinding Binding() => new VRChatCriteria();
        protected override AvatarPerformanceStatsLevelSet LevelSet() => Mobile;
                
        public override bool IsMatchingPlatform(AvatarContext avatarContext)
        {
#if UNITY_ANDROID || UNITY_IOS
            return avatarContext.AvatarRootObject.GetComponent<VRCAvatarDescriptor>();
#else
            return false;
#endif
        }
    }
}

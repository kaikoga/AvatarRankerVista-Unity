using System.Collections.Generic;
using Silksprite.AvatarRankerVista.API;
using Silksprite.AvatarRankerVista.API.Attributes;
using Silksprite.AvatarRankerVista.Generic.Criteria;
using UnityEngine;
using VRM;

namespace Silksprite.AvatarRankerVista.VRM0.Cluster
{
    [RegulationProvider]
    class ClusterVRM0Regulation : IRegulationProvider
    {
        public string Id => "net.kaikoga.arv.vrm0.cluster";
        public string DisplayName => "cluster VRM0.x";
        public int Priority => 1000;

        public bool IsMatchingPlatform(AvatarContext avatarContext)
        {
            return avatarContext.AvatarRootObject.GetComponent<VRMMeta>();
        }

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
                Id = "low",
                DisplayName = "Low",
                Color = ToColor(0xff00008b),
                Criteria = Low()
            }.Build();

            yield return new RegulationLevel.Builder
            {
                Id = "medium",
                DisplayName = "Medium",
                Color = ToColor(0xff00008b),
                Criteria = Medium()
            }.Build();

            yield return new RegulationLevel.Builder
            {
                Id = "high",
                DisplayName = "High",
                Color = ToColor(0xff00008b),
                Criteria = High()
            }.Build();

            yield return new RegulationLevel.Builder
            {
                Id = "veryHigh",
                DisplayName = "VeryHigh",
                Color = ToColor(0xff00008b),
                Criteria = VeryHigh()
            }.Build();

            yield return new RegulationLevel.Builder
            {
                Id = "compressed",
                DisplayName = "Compressed",
                Color = ToColor(0xffc71585),
                Criteria = Compressed()
            }.Build();
        }

        static IEnumerable<Criterion> Low()
        {
            yield return new Criterion<int, PolygonCount>(32000);
            yield return new Criterion<int, TexturePixelCount>(2_000_000);
            yield return new Criterion<int, MaterialSlotCount>(100);
            yield return new Criterion<int, ComponentCount<VRMSpringBone>>(0);
        }

        static IEnumerable<Criterion> Medium()
        {
            yield return new Criterion<int, PolygonCount>(32000);
            yield return new Criterion<int, TexturePixelCount>(4_000_000);
            yield return new Criterion<int, MaterialSlotCount>(100);
            yield return new Criterion<int, ComponentCount<VRMSpringBone>>(0);
        }

        static IEnumerable<Criterion> High()
        {
            yield return new Criterion<int, PolygonCount>(64000);
            yield return new Criterion<int, TexturePixelCount>(4_000_000);
            yield return new Criterion<int, MaterialSlotCount>(100);
            yield return new Criterion<int, ComponentCount<VRMSpringBone>>(int.MaxValue);
        }

        static IEnumerable<Criterion> VeryHigh()
        {
            yield return new Criterion<int, PolygonCount>(80000);
            yield return new Criterion<int, TexturePixelCount>(12_000_000);
            yield return new Criterion<int, MaterialSlotCount>(100);
            yield return new Criterion<int, ComponentCount<VRMSpringBone>>(int.MaxValue);
        }

        static IEnumerable<Criterion> Compressed()
        {
            yield break;
        }
    }
}

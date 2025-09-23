using System.Collections.Generic;
using Silksprite.AvatarRankerVista.API;
using Silksprite.AvatarRankerVista.API.Attributes;
using Silksprite.AvatarRankerVista.Generic.Criteria;
using UnityEngine;
using UniVRM10;

namespace Silksprite.AvatarRankerVista.VRM1.Cluster
{
    [RegulationProvider]
    class ClusterVRM1Regulation : IRegulationProvider
    {
        public string Id => "net.kaikoga.arv.vrm1.cluster";
        public string DisplayName => "cluster VRM1.0";
        public int Priority => 1000;

        public bool IsMatchingPlatform(AvatarContext avatarContext)
        {
            return avatarContext.AvatarRootObject.GetComponent<Vrm10Instance>();
        }

        public IEnumerable<RegulationLevel> DefineLevels()
        {
            yield return new RegulationLevel.Builder
            {
                Id = "original",
                DisplayName = "Original",
                Criteria = Original()
            }.Build();

            yield return new RegulationLevel.Builder
            {
                Id = "compressed",
                DisplayName = "Compressed",
                Criteria = Compressed()
            }.Build();

            yield return new RegulationLevel.Builder
            {
                Id = "unlimited",
                DisplayName = "Unlimited",
                Criteria = Unlimited()
            }.Build();
        }

        static IEnumerable<Criterion> Original()
        {
            yield return new Criterion<int, ComponentCount<Transform>>(1000);
            yield return new Criterion<int, ComponentCount<VRM10SpringBoneJoint>>(200);
            yield return new Criterion<int, ComponentCount<VRM10SpringBoneCollider>>(500);
            yield return new Criterion<int, MaterialSlotCount>(25);
            yield return new Criterion<int, PolygonCount>(72000);
            yield return new Criterion<int, MaterialCount>(25);
            yield return new Criterion<int, TextureSize>(8192);
            yield return new Criterion<int, TexturePixelCount>(12_582_912);
            yield return new Criterion<int, ComponentCount<IVrm10Constraint>>(50);
        }

        static IEnumerable<Criterion> Compressed()
        {
            yield return new Criterion<int, TexturePixelCount>(int.MaxValue);
        }

        static IEnumerable<Criterion> Unlimited()
        {
            yield break;
        }
    }
}

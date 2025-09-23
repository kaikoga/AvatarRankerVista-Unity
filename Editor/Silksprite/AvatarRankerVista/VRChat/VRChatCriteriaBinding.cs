using System.Collections.Generic;
using Silksprite.AvatarRankerVista.API;
using Silksprite.AvatarRankerVista.Generic.Criteria;
using Silksprite.AvatarRankerVista.VRChat.Criteria;
using UnityEngine;
using VRC.Dynamics;
using VRC.SDK3.Dynamics.PhysBone.Components;
using VRC.SDKBase.Validation.Performance.Stats;

namespace Silksprite.AvatarRankerVista.VRChat
{
    abstract class VRChatCriteriaBinding
    {
        public abstract IEnumerable<Criterion> Build(AvatarPerformanceStatsLevel level);
    }

    abstract class VRChatCriteriaBinding<
        TPolyCount,
        TAabb,
        TSkinnedMeshCount,
        TMeshCount,
        TMaterialCount,
        TAnimatorCount,
        TBoneCount,
        TLightCount,
        TParticleSystemCount,
        TParticleTotalCount,
        TParticleMaxMeshPolyCount,
        TParticleTrailsEnabled,
        TParticleCollisionEnabled,
        TTrailRendererCount,
        TLineRendererCount,
        TClothCount,
        TClothMaxVertices,
        TPhysicsColliderCount,
        TPhysicsRigidBodyCount,
        TAudioSourceCount,
        TTextureMegabytes,
        TPhysBoneComponentCount,
        TPhysBoneTransformCount,
        TPhysBoneColliderCount,
        TPhysBoneCollisionCheckCount,
        TContactCount,
        TConstraintsCount,
        TConstraintsDepth
    > : VRChatCriteriaBinding
    where TPolyCount : class, ICriterionProvider<int>
    where TAabb : class, ICriterionProvider<Vector3>
    where TSkinnedMeshCount : class, ICriterionProvider<int>
    where TMeshCount : class, ICriterionProvider<int>
    where TMaterialCount : class, ICriterionProvider<int>
    where TAnimatorCount : class, ICriterionProvider<int>
    where TBoneCount : class, ICriterionProvider<int>
    where TLightCount : class, ICriterionProvider<int>
    where TParticleSystemCount : class, ICriterionProvider<int>
    where TParticleTotalCount : class, ICriterionProvider<int>
    where TParticleMaxMeshPolyCount : class, ICriterionProvider<int>
    where TParticleTrailsEnabled : class, ICriterionProvider<int>
    where TParticleCollisionEnabled : class, ICriterionProvider<int>
    where TTrailRendererCount : class, ICriterionProvider<int>
    where TLineRendererCount : class, ICriterionProvider<int>
    where TClothCount : class, ICriterionProvider<int>
    where TClothMaxVertices : class, ICriterionProvider<int>
    where TPhysicsColliderCount : class, ICriterionProvider<int>
    where TPhysicsRigidBodyCount : class, ICriterionProvider<int>
    where TAudioSourceCount : class, ICriterionProvider<int>
    where TTextureMegabytes : class, ICriterionProvider<float>
    where TPhysBoneComponentCount : class, ICriterionProvider<int>
    where TPhysBoneTransformCount : class, ICriterionProvider<int>
    where TPhysBoneColliderCount : class, ICriterionProvider<int>
    where TPhysBoneCollisionCheckCount : class, ICriterionProvider<int>
    where TContactCount : class, ICriterionProvider<int>
    where TConstraintsCount : class, ICriterionProvider<int>
    where TConstraintsDepth : class, ICriterionProvider<int>
    {
        public override IEnumerable<Criterion> Build(AvatarPerformanceStatsLevel level)
        {
            yield return new Criterion<int, TPolyCount>(level.polyCount);
            yield return new Criterion<Vector3, TAabb>(level.aabb.size);
            yield return new Criterion<int, TSkinnedMeshCount>(level.skinnedMeshCount);
            yield return new Criterion<int, TMeshCount>(level.meshCount);
            yield return new Criterion<int, TMaterialCount>(level.materialCount);
            yield return new Criterion<int, TAnimatorCount>(level.animatorCount);
            yield return new Criterion<int, TBoneCount>(level.boneCount);
            yield return new Criterion<int, TLightCount>(level.lightCount);
            yield return new Criterion<int, TParticleSystemCount>(level.particleSystemCount);
            yield return new Criterion<int, TParticleTotalCount>(level.particleTotalCount);
            yield return new Criterion<int, TParticleMaxMeshPolyCount>(level.particleMaxMeshPolyCount);
            yield return new Criterion<int, TParticleTrailsEnabled>(level.particleTrailsEnabled ? 1 : 0);
            yield return new Criterion<int, TParticleCollisionEnabled>(level.particleCollisionEnabled ? 1 : 0);
            yield return new Criterion<int, TTrailRendererCount>(level.trailRendererCount);
            yield return new Criterion<int, TLineRendererCount>(level.lineRendererCount);
            yield return new Criterion<int, TClothCount>(level.clothCount);
            yield return new Criterion<int, TClothMaxVertices>(level.clothMaxVertices);
            yield return new Criterion<int, TPhysicsColliderCount>(level.physicsColliderCount);
            yield return new Criterion<int, TPhysicsRigidBodyCount>(level.physicsRigidbodyCount);
            yield return new Criterion<int, TAudioSourceCount>(level.audioSourceCount);
            yield return new Criterion<float, TTextureMegabytes>(level.textureMegabytes);
            yield return new Criterion<int, TPhysBoneComponentCount>(level.physBone.componentCount);
            yield return new Criterion<int, TPhysBoneTransformCount>(level.physBone.transformCount);
            yield return new Criterion<int, TPhysBoneColliderCount>(level.physBone.colliderCount);
            yield return new Criterion<int, TPhysBoneCollisionCheckCount>(level.physBone.collisionCheckCount);
            yield return new Criterion<int, TContactCount>(level.contactCount);
            yield return new Criterion<int, TConstraintsCount>(level.constraintsCount);
            yield return new Criterion<int, TClothMaxVertices>(level.clothMaxVertices);
            yield return new Criterion<int, TConstraintsDepth>(level.constraintDepth);
        }
    }

    class VRChatCriteria : VRChatCriteriaBinding<
        VRChatPolyCount,
        VRChatAABBSize,
        VRChatSkinnedMeshCount,
        VRChatMeshCount,
        VRChatMaterialCount,
        VRChatAnimatorCount,
        VRChatBoneCount,
        VRChatLightCount,
        VRChatParticleSystemCount,
        VRChatParticleTotalCount,
        VRChatParticleMaxMeshPolyCount,
        VRChatParticleTrailsEnabled,
        VRChatParticleCollisionEnabled,
        VRChatTrailRendererCount,
        VRChatLineRendererCount,
        VRChatClothCount,
        VRChatClothMaxVertices,
        VRChatPhysicsColliderCount,
        VRChatPhysicsRigidBodyCount,
        VRChatAudioSourceCount,
        VRChatTextureMegabytes,
        VRChatPhysBoneComponentCount,
        VRChatPhysBoneTransformCount,
        VRChatPhysBoneColliderCount,
        VRChatPhysBoneCollisionCheckCount,
        VRChatContactCount,
        VRChatConstraintCount,
        VRChatConstraintDepth
    >
    {
    }

    class VRChatGenericCriteria : VRChatCriteriaBinding<
        PolygonCount,
        AABBSize,
        ComponentCount<SkinnedMeshRenderer>,
        ComponentCount<MeshRenderer>,
        MaterialSlotCount,
        ComponentCount<Animator>,
        DummyCriteria<int>,
        ComponentCount<Light>,
        DummyCriteria<int>,
        DummyCriteria<int>,
        DummyCriteria<int>,
        DummyCriteria<int>,
        DummyCriteria<int>,
        ComponentCount<TrailRenderer>,
        ComponentCount<LineRenderer>,
        ComponentCount<Cloth>,
        DummyCriteria<int>,
        ComponentCount<Collider>,
        ComponentCount<Rigidbody>,
        ComponentCount<AudioSource>,
        DummyCriteria<float>,
        ComponentCount<VRCPhysBone>,
        DummyCriteria<int>,
        ComponentCount<VRCPhysBoneCollider>,
        DummyCriteria<int>,
        DummyCriteria<int>,
        ComponentCount<VRCConstraintBase>,
        DummyCriteria<int>
    >
    {
    }
}

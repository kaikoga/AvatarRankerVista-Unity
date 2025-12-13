using System;
using Ablet.API;
using Unity.Burst;

namespace Silksprite.AvatarRankerVista.Core.Serialized
{
    [Serializable]
    public class SerializedAvatarReportList
    {
        public SerializedAvatarReport[] avatarReports = { };
    }

    [Serializable]
    public class SerializedAvatarReport : IAbletSerializedBuildReportPayload.WithDiscriminator, IAbletSerializedBuildReportPayload.WithPriority
    {
        public SerializedAvatarReference avatarReference;
        public AvatarReportOrigin origin;
        public SerializedRegulationRef regulation;
        public SerializedRegulationLevelRef overallLevel;
        public SerializedAvatarReportEntry[] result;

        string IAbletSerializedBuildReportPayload.WithDiscriminator.Discriminator => regulation.id;
        int IAbletSerializedBuildReportPayload.WithPriority.Priority => (int)origin;
    }

#pragma warning disable CS0660
    [Serializable]
    public struct SerializedAvatarReference : IEquatable<SerializedAvatarReference>
    {
        public string sceneName;
        public string path;

        public string Name => System.IO.Path.GetFileName(path);

        public string FullName => $"{sceneName}:{Name}";
        public string DisplayName => SerializedAvatarReportRepository.instance.IsMultiScene ? FullName : Name;

        public override string ToString() => DisplayName;

        public bool Equals(SerializedAvatarReference other)
        {
            return sceneName == other.sceneName && path == other.path;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(sceneName, path);
        }

        public static bool operator ==(SerializedAvatarReference left, SerializedAvatarReference right)
        {
            return left.Equals(right);
        }

        public static bool operator !=(SerializedAvatarReference left, SerializedAvatarReference right)
        {
            return !left.Equals(right);
        }
    }
#pragma warning restore CS0660

    [Serializable]
    public struct SerializedRegulationRef
    {
        public string id;
        public string displayName;
    }

    [Serializable]
    public struct SerializedRegulationLevelRef
    {
        public string id;
        public string displayName;
    }

    [Serializable]
    public struct SerializedCriterionRef
    {
        public string id;
        public string displayName;
        public string value;
    }

    [Serializable]
    public class SerializedAvatarReportEntry
    {
        public SerializedCriterionRef criterion;
        public SerializedRegulationLevelRef level;
        public string recommendedValue;
        public SerializedRegulationLevelRef recommendedLevel;
    }
}
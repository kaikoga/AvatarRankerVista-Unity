using System;
using Silksprite.AvatarRankerVista.Core;
using Silksprite.AvatarRankerVista.Core.Serialized;
using Silksprite.AvatarRankerVista.Window;

namespace Silksprite.AvatarRankerVista.Core.Serialized
{
    [Serializable]
    public class SerializedAvatarReportList
    {
        public SerializedAvatarReport[] avatarReports = { };
    }
}
namespace Silksprite.AvatarRankerVista.Window
{

    [Serializable]
    public class SerializedAvatarReport
    {
        public SerializedAvatarName avatarName;
        public AvatarReportOrigin origin;
        public SerializedRegulationRef regulation;
        public SerializedRegulationLevelRef overallLevel;
        public SerializedAvatarReportEntry[] result;
    }

    [Serializable]
    public struct SerializedAvatarName : IEquatable<SerializedAvatarName>
    {
        public string sceneName;
        public string name;

        public string FullName => $"{sceneName}:{name}";
        public string DisplayName => SerializedAvatarReportRepository.instance.IsMultiScene ? FullName : name;

        public override string ToString() => DisplayName;

        public bool Equals(SerializedAvatarName other)
        {
            return sceneName == other.sceneName && name == other.name;
        }
        public override bool Equals(object obj)
        {
            return obj is SerializedAvatarName other && Equals(other);
        }
        public override int GetHashCode()
        {
            return HashCode.Combine(sceneName, name);
        }
        public static bool operator ==(SerializedAvatarName left, SerializedAvatarName right)
        {
            return left.Equals(right);
        }
        public static bool operator !=(SerializedAvatarName left, SerializedAvatarName right)
        {
            return !left.Equals(right);
        }
    }

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

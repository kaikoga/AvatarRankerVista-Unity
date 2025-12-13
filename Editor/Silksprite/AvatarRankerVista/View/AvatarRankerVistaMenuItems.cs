using Silksprite.AvatarRankerVista.Core.Serialized;
using UnityEditor;

namespace Silksprite.AvatarRankerVista.View
{
    static class AvatarRankerVistaMenuItems
    {
        [InitializeOnLoadMethod]
        static void Init()
        {
            EditorApplication.delayCall += RefreshSettings;
            AvatarRankerSettingsRepository.instance.Changed += RefreshSettings;
        }

        static void RefreshSettings()
        {
            Menu.SetChecked("Tools/Avatar Tinker Vista/Avatar Ranker Vista - Measure on Build", AvatarRankerSettingsRepository.instance.MeasureOnBuild);
        }
        
        [MenuItem("Tools/Avatar Tinker Vista/Avatar Ranker Vista - Measure on Build", false, 100001)]
        static void MeasureOnBuild()
        {
            AvatarRankerSettingsRepository.instance.MeasureOnBuild = !AvatarRankerSettingsRepository.instance.MeasureOnBuild;
        }
    }
}
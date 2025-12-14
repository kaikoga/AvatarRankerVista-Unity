using Ablet.Registries;
using Silksprite.AvatarRankerVista.Core.Serialized;
using Silksprite.AvatarRankerVista.Core.Utils;
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

        [MenuItem("Tools/Avatar Tinker Vista/Avatar Ranker Vista - Manual Measure", true, 100002)]
        static bool ValidateManualMeasure()
        {
            return Selection.activeGameObject
                   && PlatformRegistry.Instance.TryGuessPlatform(Selection.activeGameObject, out _);
        }
        
        [MenuItem("Tools/Avatar Tinker Vista/Avatar Ranker Vista - Manual Measure", false, 100002)]
        static void ManualMeasure()
        {
            AvatarReportService.MeasureAll(Selection.activeGameObject, false);
        }
    }
}
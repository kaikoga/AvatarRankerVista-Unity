using Silksprite.AvatarRankerVista.Core.Serialized;
using Silksprite.AvatarRankerVista.View.Window;
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
            Menu.SetChecked("Tools/Avatar Tinker Vista/Measure on Build", AvatarRankerSettingsRepository.instance.MeasureOnBuild);
            Menu.SetChecked("Tools/Avatar Tinker Vista/Show Report on Build", AvatarRankerSettingsRepository.instance.ShowReportOnBuild);
        }
        
        [MenuItem("Tools/Avatar Tinker Vista/Avatar Ranker Vista Window", false, 100000)]
        static void ShowWindow()
        {
            AvatarRankerVistaWindow.ShowWindow();
        }
        
        [MenuItem("Tools/Avatar Tinker Vista/Measure on Build", false, 100001)]
        static void MeasureOnBuild()
        {
            AvatarRankerSettingsRepository.instance.MeasureOnBuild = !AvatarRankerSettingsRepository.instance.MeasureOnBuild;
        }
        
        [MenuItem("Tools/Avatar Tinker Vista/Show Report on Build", false, 100002)]
        static void ShowReportOnBuild()
        {
            AvatarRankerSettingsRepository.instance.ShowReportOnBuild = !AvatarRankerSettingsRepository.instance.ShowReportOnBuild;
        }
    }
}
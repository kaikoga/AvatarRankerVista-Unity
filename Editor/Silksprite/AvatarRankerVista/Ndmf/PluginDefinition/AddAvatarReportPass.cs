using nadena.dev.ndmf;
using Silksprite.AvatarRankerVista.Core.Utils;

namespace Silksprite.AvatarRankerVista.Ndmf.PluginDefinition
{
    class AddAvatarReportPass : Pass<AddAvatarReportPass>
    {
        protected override void Execute(BuildContext context)
        {
            if (context.PlatformProvider.QualifiedName != WellKnownPlatforms.VRChatAvatar30)
            {
                AvatarReportService.MeasureAll(context.AvatarRootObject, true);
            }
        }
    }
}

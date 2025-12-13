using Ablet.API.V1;
using Ablet.API.V1.Attributes;
using Ablet.API.V1.Building;
using Ablet.Builtin;
using Silksprite.AvatarRankerVista.Core.Utils;

namespace Silksprite.AvatarRankerVista.Ablet
{
    [AbletLayer]
    class AvatarRankerVistaLayer : IAbletLayer
    {
        public string Id => "net.kaikoga.arv";
        public string DisplayName => "Avatar Ranker Vista";
        
        public void Configure(IDependencyConfigurator config)
        {
            config.AddDependency<ExportingPhase>();
        }
        public AbletProcedure ToProcedure(IBuildArgument argument)
        {
            return AbletBuildProcedure.Create(context =>
            {
                if (context.Argument.Platform.Id != BuiltinPlatformIds.VRChatAvatarSDK3)
                {
                    AvatarReportService.MeasureAll(context.CurrentRootObject, true);
                }
            });
        }
    }
}

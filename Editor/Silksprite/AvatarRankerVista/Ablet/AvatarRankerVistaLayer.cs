using System;
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
        public string Id => "Silksprite.AvatarRankerVista";
        public string DisplayName => "Avatar Ranker Vista";
        
        public void Configure(IDependencyConfigurator config)
        {
            config.AddDependency<ExportingPhase>();
        }
        public AbletProcedure ToProcedure(IBuildArgument argument)
        {
            switch (argument.BuildInitiationSourceMode)
            {
                case BuildInitiationSourceMode.Ablet:
                    return AbletBuildProcedure.Create(context =>
                    {
                        AvatarReportService.MeasureAll(context.CurrentRootObject, true);
                    });
                case BuildInitiationSourceMode.PlatformBuild:
                case BuildInitiationSourceMode.NDMF:
                    return null;
                default:
                    throw new ArgumentOutOfRangeException(nameof(argument.BuildInitiationSourceMode));
            }
        }
    }
}

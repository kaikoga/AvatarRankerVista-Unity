using System;
using nadena.dev.ndmf;
using Silksprite.AvatarRankerVista.Ndmf.PluginDefinition;
using UnityEngine;

[assembly: ExportsPlugin(typeof(AvatarRankerVistaPlugin))]
namespace Silksprite.AvatarRankerVista.Ndmf.PluginDefinition
{
    // runs independently of NDMF platform
    [RunsOnAllPlatforms]
    class AvatarRankerVistaPlugin : Plugin<AvatarRankerVistaPlugin>
    {
        public override string QualifiedName => "net.kaikoga.arv";
        public override string DisplayName => "Avatar Ranker Vista";

        protected override void OnUnhandledException(Exception e)
        {
            Debug.LogException(e);
        }

        protected override void Configure()
        {
            InPhase(BuildPhase.PlatformFinish).Run(AddAvatarReportPass.Instance);
        }
    }
}

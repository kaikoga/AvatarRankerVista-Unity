using Silksprite.AvatarRankerVista.Core.Utils;
using UnityEngine;
using VRC.SDKBase.Editor.BuildPipeline;

namespace Silksprite.AvatarRankerVista.VRChat
{
    class AddAvatarReportPreprocessor : IVRCSDKPreprocessAvatarCallback
    {
        public int callbackOrder => int.MaxValue;
        
        public bool OnPreprocessAvatar(GameObject avatarGameObject)
        {
            AvatarReportService.MeasureAll(avatarGameObject, true);
            return true;
        }
    }
}

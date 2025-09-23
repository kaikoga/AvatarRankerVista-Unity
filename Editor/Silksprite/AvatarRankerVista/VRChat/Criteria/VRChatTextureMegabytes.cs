using JetBrains.Annotations;
using Silksprite.AvatarRankerVista.API;

namespace Silksprite.AvatarRankerVista.VRChat.Criteria
{
    [PublicAPI]
    class VRChatTextureMegabytes : ICriterionProvider<float>
    {
        public string Id => "net.kaikoga.arv.vrchat.textureMegabytes";
        public string DisplayName => "Texture Memory";
        
        public float Measure(AvatarContext context)
        {
            return context.GetVRChatAvatarPerformanceStats().textureMegabytes ?? -1;
        }
    }
}

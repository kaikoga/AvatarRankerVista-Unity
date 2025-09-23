using JetBrains.Annotations;
using Silksprite.AvatarRankerVista.API;

namespace Silksprite.AvatarRankerVista.VRChat.Criteria
{
    [PublicAPI]
    class VRChatAudioSourceCount : ICriterionProvider<int>
    {
        public string Id => "net.kaikoga.arv.vrchat.audioSourceCount";
        public string DisplayName => "AudioSource Count";
        
        public int Measure(AvatarContext context)
        {
            return context.GetVRChatAvatarPerformanceStats().audioSourceCount ?? -1;
        }
    }
}

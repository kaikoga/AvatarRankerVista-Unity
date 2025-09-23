using Silksprite.AvatarRankerVista.API;
using Silksprite.AvatarRankerVista.VRChat.Memo;
using VRC.SDKBase.Validation.Performance;
using VRC.SDKBase.Validation.Performance.Stats;

namespace Silksprite.AvatarRankerVista.VRChat.Memo
{
    class MemoizeGetVRChatAvatarPerformanceStats : IMemoProvider<AvatarPerformanceStats>
    {
        public AvatarPerformanceStats Resolve(AvatarContext context)
        {
            var stats = new AvatarPerformanceStats(false);
            if (context.AvatarRootObject)
            {
                AvatarPerformanceStats.Initialize();
                AvatarPerformance.CalculatePerformanceStats(context.AvatarRootObject.name, context.AvatarRootObject, stats, false);
            }
            return stats;
        }
    }
}

namespace Silksprite.AvatarRankerVista.API
{
    static class GetVRChatAvatarPerformanceStatsExtension
    {
        public static AvatarPerformanceStats GetVRChatAvatarPerformanceStats(this AvatarContext context)
        {
            return context.Resolve<AvatarPerformanceStats, MemoizeGetVRChatAvatarPerformanceStats>();
        }
    }
}

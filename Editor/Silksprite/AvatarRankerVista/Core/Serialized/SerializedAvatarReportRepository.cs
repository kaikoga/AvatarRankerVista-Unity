using System;
using System.Collections.Generic;
using System.Linq;
using Silksprite.AvatarRankerVista.Window;
using UnityEditor;
using UnityEngine;

namespace Silksprite.AvatarRankerVista.Core.Serialized
{
    public class SerializedAvatarReportRepository : ScriptableSingleton<SerializedAvatarReportRepository>
    {
        [SerializeField]
        List<SerializedAvatarReport> avatarReports = new List<SerializedAvatarReport>();

        public bool IsMultiScene { get; private set; }
        public IEnumerable<SerializedAvatarName> AvatarNames => avatarReports.Select(x => x.avatarName).Distinct();

        public event Action Changed;

        void OnChange()
        {
            IsMultiScene = AvatarNames.Select(name => name.sceneName).Distinct().Count() > 1;
            Changed?.Invoke();
        }

        public void AddRange(IEnumerable<SerializedAvatarReport> reports)
        {
            foreach (var report in reports)
            {
                DoAdd(report);
            }
            OnChange();
        }

        void DoAdd(SerializedAvatarReport avatarReport)
        {
            for (var i = 0; i < avatarReports.Count; i++)
            {
                var report = avatarReports[i];
                if (report.avatarName != avatarReport.avatarName
                    || report.regulation.id != avatarReport.regulation.id)
                {
                    continue;
                }
                if (report.origin <= avatarReport.origin)
                {
                    avatarReports[i] = avatarReport;
                }
                return;
            }
            avatarReports.Add(avatarReport);
        }

        public IEnumerable<SerializedAvatarReport> ForAvatars(SerializedAvatarName[] avatarNames)
        {
            return avatarReports.Where(report => avatarNames.Contains(report.avatarName) && AvatarRankerSettingsRepository.instance.GetRegulationEnabled(report.regulation));
        }

        public void Clear()
        {
            avatarReports.Clear();
            OnChange();
        }
    }
}

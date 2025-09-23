using System;
using System.Collections.Generic;
using Silksprite.AvatarRankerVista.Window;
using UnityEditor;
using UnityEngine;

namespace Silksprite.AvatarRankerVista.Core.Serialized
{
    public class AvatarRankerSettingsRepository : ScriptableSingleton<AvatarRankerSettingsRepository>
    {
        const string MeasureOnBuildPrefsKey = "net.kaikoga.arv.Settings.MeasureOnBuild"; 
        const string ShowReportOnBuildPrefsKey = "net.kaikoga.arv.Settings.ShowReportOnBuild"; 
 
        [SerializeField]
        public List<string> excludedRegulationIds = new List<string>();

        [SerializeField]
        bool showFullReport;

        public event Action Changed;

        public bool ShowFullReport
        {
            get => showFullReport;
            set
            {
                showFullReport = value;
                Changed?.Invoke();
            }
        }

        public bool MeasureOnBuild
        {
            get => EditorPrefs.GetBool(MeasureOnBuildPrefsKey, true);
            set
            {
                EditorPrefs.SetBool(MeasureOnBuildPrefsKey, value);
                Changed?.Invoke();
            }
        }

        public bool ShowReportOnBuild
        {
            get => EditorPrefs.GetBool(ShowReportOnBuildPrefsKey, true);
            set
            {
                EditorPrefs.SetBool(ShowReportOnBuildPrefsKey, value);
                Changed?.Invoke();
            }
        }

        public bool GetRegulationEnabled(SerializedRegulationRef regulation) => GetRegulationEnabled(regulation.id);
        public bool GetRegulationEnabled(Regulation regulation) => GetRegulationEnabled(regulation.Id);
        bool GetRegulationEnabled(string id) => !excludedRegulationIds.Contains(id);

        public void SetRegulationEnabled(Regulation regulation, bool value)
        {
            excludedRegulationIds.Remove(regulation.Id);
            if (!value)
            {
                excludedRegulationIds.Add(regulation.Id);
            }
            Changed?.Invoke();
        }
    }
}

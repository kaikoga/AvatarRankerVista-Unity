using System.Linq;
using Silksprite.AvatarRankerVista.Core;
using Silksprite.AvatarRankerVista.Core.Serialized;
using Silksprite.AvatarRankerVista.View.UIElements;
using UnityEngine.UIElements;

namespace Silksprite.AvatarRankerVista.View.Window
{
    public class SettingsUIWindow : VisualElement
    {
        readonly RegulationListView _regulationListView;
        readonly Toggle _showFullReport;

        public SettingsUIWindow()
        {
            _regulationListView = new RegulationListView();
            _regulationListView.Draw(RegulationRepository.Instance.AllRegulations().ToList());
            hierarchy.Add(_regulationListView);

            _showFullReport = new Toggle
            {
                label = "Show Full Report",
                value = AvatarRankerSettingsRepository.instance.ShowFullReport
            };
            hierarchy.Add(_showFullReport);
            
            _showFullReport.RegisterValueChangedCallback(evt => OnShowFullReportChanged(evt.newValue));
            _regulationListView.Draw(RegulationRepository.Instance.AllRegulations().ToList());
        }
        
        void OnShowFullReportChanged(bool newValue)
        {
            AvatarRankerSettingsRepository.instance.ShowFullReport = newValue;
        }
    }
}

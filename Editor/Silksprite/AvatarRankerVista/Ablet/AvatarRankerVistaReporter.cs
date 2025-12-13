using System;
using System.Linq;
using Ablet.API;
using Ablet.API.V1.Attributes;
using Ablet.EditorAPI.V1;
using Ablet.EditorAPI.V1.Attributes;
using Ablet.EditorAPI.V1.Extensions.BuildReporter;
using Silksprite.AvatarRankerVista.Core;
using Silksprite.AvatarRankerVista.Core.Serialized;
using Silksprite.AvatarRankerVista.View.UIElements;
using UnityEditor;
using UnityEngine.UIElements;

namespace Silksprite.AvatarRankerVista.Ablet
{
    [AbletBuildReporter]
    class AvatarRankerVistaReporter : IAbletBuildReporter
    {
        const string UssPath = "Packages/net.kaikoga.arv/Editor/Silksprite/AvatarRankerVista/View/Uxml/AvatarRankerVista.uss";

        string IAbletDefinition.Id => "net.kaikoga.arv.reporting";
        string IAbletDefinition.DisplayName => "Avatar Ranker Vista";
        
        Type IAbletBuildReporter.ForType => typeof(SerializedAvatarReport);

        StyleSheet IAbletBuildReporter.StyleSheet => AssetDatabase.LoadAssetAtPath<StyleSheet>(UssPath);

        VisualElement IAbletBuildReporter.Render(IAbletSerializedBuildReportPayload payload)
        {
            var avatarReport = (SerializedAvatarReport)payload;
            if (!AvatarRankerSettingsRepository.instance.GetRegulationEnabled(avatarReport.regulation))
            {
                return null;
            }
            var errorReportView = new SerializedAvatarReportView();
            errorReportView.Draw(avatarReport);
            return errorReportView;
        }
    }

    [AbletExtension]
    class AvatarRankerVistaSettingsUIExtension : ISettingsUIExtension
    {
        public Type ForType => typeof(AvatarRankerVistaReporter);

        public VisualElement RenderSettingsUI()
        {
            var regulationListView = new RegulationListView();
            regulationListView.Draw(RegulationRepository.Instance.AllRegulations().ToList());
            return regulationListView;
        }
    }
}

using System;
using Ablet.API;
using Ablet.API.V1;
using Ablet.API.V1.Attributes;
using Ablet.EditorAPI.V1;
using Ablet.EditorAPI.V1.Attributes;
using Ablet.EditorAPI.V1.Extensions.BuildReporter;
using Silksprite.AvatarRankerVista.Core.Serialized;
using Silksprite.AvatarRankerVista.Core.Utils;
using Silksprite.AvatarRankerVista.View.UIElements;
using Silksprite.AvatarRankerVista.View.Window;
using UnityEditor;
using UnityEngine;
using UnityEngine.UIElements;

using LElements = Silksprite.Loch.UIElements;

using static Silksprite.Loch.Tools.LochTool;

namespace Silksprite.AvatarRankerVista.Ablet
{
    [AbletBuildReporter]
    class AvatarRankerVistaReporter : IAbletBuildReporter
    {
        const string UssPath = "Packages/net.kaikoga.arv/Editor/Silksprite/AvatarRankerVista/View/Uxml/AvatarRankerVista.uss";

        string IAbletDefinition.Id => "Silksprite.AvatarRankerVista.Reporting";
        string IAbletDefinition.DisplayName => "Avatar Ranker Vista";
        
        Type IAbletBuildReporter.ForType => typeof(SerializedAvatarReport);

        StyleSheet IAbletBuildReporter.StyleSheet => AssetDatabase.LoadAssetAtPath<StyleSheet>(UssPath);

        VisualElement IAbletBuildReporter.Render(IAbletSerializedBuildReportPayload payload, GameObject entrypointObject)
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
        Type IAbletExtension.ForType => typeof(AvatarRankerVistaReporter);

        VisualElement ISettingsUIExtension.RenderSettingsUI() => new SettingsUIWindow();
    }

    [AbletExtension]
    class AvatarRankerVistaManualReportUIExtension : IManualReportUIExtension
    {
        Type IAbletExtension.ForType => typeof(AvatarRankerVistaReporter);

        VisualElement IManualReportUIExtension.RenderManualReportUI(GameObject entrypointObject)
        {
            var container = new VisualElement();
            var button = new LElements.Button
            {
                text = "Measure EditMode (Avatar Ranker Vista)",
                loc = Loc("AvatarRankerVistaManualReportUIExtension::measureEditModeButton")
            };
            button.clicked += () => AvatarReportService.MeasureAll(entrypointObject, false);
            container.Add(button);
            return container;
        }
    }
}

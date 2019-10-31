using Nop.Core;
using Nop.Services.Plugins;
using Nop.Services.Common;
using Nop.Services.Configuration;
using Nop.Services.Localization;

namespace Nop.Plugin.Misc.ApplicationInsights
{
    /// <summary>
    /// Represents method for the Application Insights integration
    /// </summary>
    public class ApplicationInsightsMethod : BasePlugin, IMiscPlugin
    {
        #region Fields

        private readonly ILocalizationService _localizationService;
        private readonly ISettingService _settingService;
        private readonly IWebHelper _webHelper;

        #endregion

        #region Ctor

        public ApplicationInsightsMethod(ILocalizationService localizationService,
            ISettingService settingService,
            IWebHelper webHelper)
        {
            this._localizationService = localizationService;
            this._settingService = settingService;
            this._webHelper = webHelper;
        }

        #endregion

        #region Methods

        /// <summary>
        /// Gets a configuration page URL
        /// </summary>
        public override string GetConfigurationPageUrl()
        {
            return $"{_webHelper.GetStoreLocation()}Admin/MiscApplicationInsights/Configure";
        }

        /// <summary>
        /// Gets a name of a view component for displaying plugin in public store
        /// </summary>
        /// <returns>View component name</returns>
        public string GetPublicViewComponentName()
        {
            return ApplicationInsightsDefaults.VIEW_COMPONENT_NAME;
        }

        /// <summary>
        /// Install the plugin
        /// </summary>
        public override void Install()
        {
            //settings
            _settingService.SaveSetting(new ApplicationInsightsSettings());

            //locales
            _localizationService.AddOrUpdatePluginLocaleResource("Plugins.Misc.ApplicationInsights.Instructions", "<h3>Configuration:</h3><br/><p><ol><li>Sign in to the Microsoft Azure Portal</li><li>Create a new Application Insights resource</li><li>Navigate to your newly created resource: myResource -> overview</li><li>Copy the instrumentation key and paste it below</li><li><b>Restart the application in order to apply the new key and settings!</b></li></ol></p><br />");
            _localizationService.AddOrUpdatePluginLocaleResource("Plugins.Misc.ApplicationInsights.InstrumentationKey", "Instrumentation Key");
            _localizationService.AddOrUpdatePluginLocaleResource("Plugins.Misc.ApplicationInsights.InstrumentationKey.Hint", "Enter your Application Insights resources instrumentation key");
            _localizationService.AddOrUpdatePluginLocaleResource("Plugins.Misc.ApplicationInsights.EnableQuickPulseMetricStream", "Live Metrics Stream");
            _localizationService.AddOrUpdatePluginLocaleResource("Plugins.Misc.ApplicationInsights.EnableQuickPulseMetricStream.Hint", "Check the box whether you want to enable or disable Live Metrics Stream feature");
            _localizationService.AddOrUpdatePluginLocaleResource("Plugins.Misc.ApplicationInsights.EnableAdaptiveSampling", "Adaptive Sampling");
            _localizationService.AddOrUpdatePluginLocaleResource("Plugins.Misc.ApplicationInsights.EnableAdaptiveSampling.Hint", "Check the box whether you want to enable or disable Adaptive Sampling feature");
            _localizationService.AddOrUpdatePluginLocaleResource("Plugins.Misc.ApplicationInsights.EnableHeartbeat", "Heartbeat");
            _localizationService.AddOrUpdatePluginLocaleResource("Plugins.Misc.ApplicationInsights.EnableHeartbeat.Hint", "Check the box whether you want to enable or disable Heartbeats feature");
            _localizationService.AddOrUpdatePluginLocaleResource("Plugins.Misc.ApplicationInsights.AddAutoCollectedMetricExtractor", "AutoCollectedMetrics extractor");
            _localizationService.AddOrUpdatePluginLocaleResource("Plugins.Misc.ApplicationInsights.AddAutoCollectedMetricExtractor.Hint", "Check the box whether you want to enable or disable reporting of unhandled Exception tracking by the Request collection module");

            base.Install();
        }

        /// <summary>
        /// Uninstall the plugin
        /// </summary>
        public override void Uninstall()
        {
            //settings
            _settingService.DeleteSetting<ApplicationInsightsSettings>();

            //locales
            _localizationService.DeletePluginLocaleResource("Plugins.Misc.ApplicationInsights.Instructions");
            _localizationService.DeletePluginLocaleResource("Plugins.Misc.ApplicationInsights.InstrumentationKey");
            _localizationService.DeletePluginLocaleResource("Plugins.Misc.ApplicationInsights.InstrumentationKey.Hint");
            _localizationService.DeletePluginLocaleResource("Plugins.Misc.ApplicationInsights.EnableQuickPulseMetricStream");
            _localizationService.DeletePluginLocaleResource("Plugins.Misc.ApplicationInsights.EnableQuickPulseMetricStream.Hint");
            _localizationService.DeletePluginLocaleResource("Plugins.Misc.ApplicationInsights.EnableAdaptiveSampling");
            _localizationService.DeletePluginLocaleResource("Plugins.Misc.ApplicationInsights.EnableAdaptiveSampling.Hint");
            _localizationService.DeletePluginLocaleResource("Plugins.Misc.ApplicationInsights.EnableHeartbeat");
            _localizationService.DeletePluginLocaleResource("Plugins.Misc.ApplicationInsights.EnableHeartbeat.Hint");
            _localizationService.DeletePluginLocaleResource("Plugins.Misc.ApplicationInsights.AddAutoCollectedMetricExtractor");
            _localizationService.DeletePluginLocaleResource("Plugins.Misc.ApplicationInsights.AddAutoCollectedMetricExtractor.Hint");

            base.Uninstall();
        }

        #endregion
    }
}
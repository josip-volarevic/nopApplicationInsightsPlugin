using Nop.Core;
using Nop.Services.Plugins;
using Nop.Services.Common;
using Nop.Services.Configuration;
using Nop.Services.Localization;
using System.Threading.Tasks;

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
        public override async Task InstallAsync()
        {
            //settings
            await _settingService.SaveSettingAsync(new ApplicationInsightsSettings());

            //locales
            await _localizationService.AddOrUpdateLocaleResourceAsync("Plugins.Misc.ApplicationInsights.Instructions", "<h4>Configuration:</h4><br/><p><ol><li>Sign in to the Microsoft Azure Portal</li><li>Create a new Application Insights resource</li><li>Navigate to your newly created resource: myResource -> overview</li><li>Copy the instrumentation key and paste it below</li><li><b>Restart the application in order to apply the new key and settings!</b></li></ol></p><br />");
            await _localizationService.AddOrUpdateLocaleResourceAsync("Plugins.Misc.ApplicationInsights.InstrumentationKey", "Instrumentation Key");
            await _localizationService.AddOrUpdateLocaleResourceAsync("Plugins.Misc.ApplicationInsights.InstrumentationKey.Hint", "Enter your Application Insights resources instrumentation key");
            await _localizationService.AddOrUpdateLocaleResourceAsync("Plugins.Misc.ApplicationInsights.EnableQuickPulseMetricStream", "Live Metrics Stream");
            await _localizationService.AddOrUpdateLocaleResourceAsync("Plugins.Misc.ApplicationInsights.EnableQuickPulseMetricStream.Hint", "Check the box whether you want to enable or disable Live Metrics Stream feature");
            await _localizationService.AddOrUpdateLocaleResourceAsync("Plugins.Misc.ApplicationInsights.EnableAdaptiveSampling", "Adaptive Sampling");
            await _localizationService.AddOrUpdateLocaleResourceAsync("Plugins.Misc.ApplicationInsights.EnableAdaptiveSampling.Hint", "Check the box whether you want to enable or disable Adaptive Sampling feature");
            await _localizationService.AddOrUpdateLocaleResourceAsync("Plugins.Misc.ApplicationInsights.EnableHeartbeat", "Heartbeat");
            await _localizationService.AddOrUpdateLocaleResourceAsync("Plugins.Misc.ApplicationInsights.EnableHeartbeat.Hint", "Check the box whether you want to enable or disable Heartbeats feature");
            await _localizationService.AddOrUpdateLocaleResourceAsync("Plugins.Misc.ApplicationInsights.AddAutoCollectedMetricExtractor", "AutoCollectedMetrics extractor");
            await _localizationService.AddOrUpdateLocaleResourceAsync("Plugins.Misc.ApplicationInsights.AddAutoCollectedMetricExtractor.Hint", "Check the box whether you want to enable or disable reporting of unhandled Exception tracking by the Request collection module");
            await _localizationService.AddOrUpdateLocaleResourceAsync("Plugins.Misc.ApplicationInsights.GenerateCsException", "C#");
            await _localizationService.AddOrUpdateLocaleResourceAsync("Plugins.Misc.ApplicationInsights.GenerateSqlException", "SQL");
            await _localizationService.AddOrUpdateLocaleResourceAsync("Plugins.Misc.ApplicationInsights.GenerateBrowserException", "Browser");
            await base.InstallAsync();
        }

        /// <summary>
        /// Uninstall the plugin
        /// </summary>
        public override async Task UninstallAsync()
        {
            //settings
            await _settingService.DeleteSettingAsync<ApplicationInsightsSettings>();

            //locales
            await _localizationService.DeleteLocaleResourceAsync("Plugins.Misc.ApplicationInsights.Instructions");
            await _localizationService.DeleteLocaleResourceAsync("Plugins.Misc.ApplicationInsights.InstrumentationKey");
            await _localizationService.DeleteLocaleResourceAsync("Plugins.Misc.ApplicationInsights.InstrumentationKey.Hint");
            await _localizationService.DeleteLocaleResourceAsync("Plugins.Misc.ApplicationInsights.EnableQuickPulseMetricStream");
            await _localizationService.DeleteLocaleResourceAsync("Plugins.Misc.ApplicationInsights.EnableQuickPulseMetricStream.Hint");
            await _localizationService.DeleteLocaleResourceAsync("Plugins.Misc.ApplicationInsights.EnableAdaptiveSampling");
            await _localizationService.DeleteLocaleResourceAsync("Plugins.Misc.ApplicationInsights.EnableAdaptiveSampling.Hint");
            await _localizationService.DeleteLocaleResourceAsync("Plugins.Misc.ApplicationInsights.EnableHeartbeat");
            await _localizationService.DeleteLocaleResourceAsync("Plugins.Misc.ApplicationInsights.EnableHeartbeat.Hint");
            await _localizationService.DeleteLocaleResourceAsync("Plugins.Misc.ApplicationInsights.AddAutoCollectedMetricExtractor");
            await _localizationService.DeleteLocaleResourceAsync("Plugins.Misc.ApplicationInsights.AddAutoCollectedMetricExtractor.Hint");
            await _localizationService.DeleteLocaleResourceAsync("Plugins.Misc.ApplicationInsights.GenerateCsException");
            await _localizationService.DeleteLocaleResourceAsync("Plugins.Misc.ApplicationInsights.GenerateSqlException");
            await _localizationService.DeleteLocaleResourceAsync("Plugins.Misc.ApplicationInsights.GenerateBrowserException");


            await base.UninstallAsync();
        }

        #endregion
    }
}
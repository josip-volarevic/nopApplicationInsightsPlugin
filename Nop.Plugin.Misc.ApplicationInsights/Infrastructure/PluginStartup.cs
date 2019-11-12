using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Nop.Plugin.Misc.ApplicationInsights.Helpers;
using Nop.Core.Infrastructure;
using System;
using System.IO;

namespace Nop.Plugin.Misc.ApplicationInsights.Infrastructure
{
    /// <summary>
    /// Represents object for the configuring plugin on application startup
    /// </summary>
    public class PluginStartup : INopStartup
    {
        /// <summary>
        /// Add and configure any of the middleware
        /// </summary>
        /// <param name="services">Collection of service descriptors</param>
        /// <param name="configuration">Configuration of the application</param>
        public void ConfigureServices(IServiceCollection services, IConfiguration configuration)
        {
            var aiOptions = new Microsoft.ApplicationInsights.AspNetCore.Extensions.ApplicationInsightsServiceOptions();

            var config = ConfigHelper.GetConfig();

            string instrumentationKey = config["ApplicationInsights:InstrumentationKey"];
            bool enableQuickPulseMetricStream = Convert.ToBoolean(config["ApplicationInsights:Settings:EnableQuickPulseMetricStream"]);
            bool enableAdaptiveSampling = Convert.ToBoolean(config["ApplicationInsights:Settings:EnableAdaptiveSampling"]);
            bool enableHeartbeat = Convert.ToBoolean(config["ApplicationInsights:Settings:EnableHeartbeat"]);
            bool addAutoCollectedMetricExtractor = Convert.ToBoolean(config["ApplicationInsights:Settings:AddAutoCollectedMetricExtractor"]);

            // Configures instrumentation key
            aiOptions.InstrumentationKey = instrumentationKey;

            // Disables or enables Application Insights features
            aiOptions.EnableQuickPulseMetricStream = enableQuickPulseMetricStream;
            aiOptions.EnableAdaptiveSampling = enableAdaptiveSampling;
            aiOptions.EnableHeartbeat = enableHeartbeat;
            aiOptions.AddAutoCollectedMetricExtractor = addAutoCollectedMetricExtractor;

            if (string.IsNullOrEmpty(aiOptions.InstrumentationKey))
            {
                // Make sure InsutrmentationKey is not empty
                aiOptions.InstrumentationKey = "11111111-2222-3333-4444-555555555555";
            }
            services.AddApplicationInsightsTelemetry(aiOptions);
        }

        /// <summary>
        /// Configure the using of added middleware
        /// </summary>
        /// <param name="application">Builder for configuring an application's request pipeline</param>
        public void Configure(IApplicationBuilder application)
        {
        }

        /// <summary>
        /// Gets order of this startup configuration implementation
        /// </summary>
        public int Order => 11;
    }
}
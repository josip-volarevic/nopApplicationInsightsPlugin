using Nop.Core.Configuration;

namespace Nop.Plugin.Misc.ApplicationInsights
{
    /// <summary>
    /// Represents settings of the Application Insights method
    /// </summary>
    public class ApplicationInsightsSettings : ISettings
    {
        /// <summary>
        /// Gets or sets InstrumentationKey
        /// </summary>
        public string InstrumentationKey { get; set; }

        /// <summary>
        /// Gets or sets EnableQuickPulseMetricStream
        /// </summary>
        public bool EnableQuickPulseMetricStream { get; set; }

        /// <summary>
        /// Gets or sets EnableAdaptiveSampling
        /// </summary>
        public bool EnableAdaptiveSampling { get; set; }

        /// <summary>
        /// Gets or sets EnableHeartbeat
        /// </summary>
        public bool EnableHeartbeat { get; set; }
        /// <summary>
        /// Gets or sets AddAutoCollectedMetricExtractor
        /// </summary>
        public bool AddAutoCollectedMetricExtractor { get; set; }
    }
}

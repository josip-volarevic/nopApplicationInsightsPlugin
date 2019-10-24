using Nop.Core.Configuration;

namespace Nop.Plugin.Misc.ApplicationInsights
{
    /// <summary>
    /// Represents settings of the Application Insights method
    /// </summary>
    public class ApplicationInsightsSettings : ISettings
    {
        /// <summary>
        /// Gets or sets instrumentation key
        /// </summary>
        public string InstrumentationKey { get; set; }

    }
}

using Nop.Web.Framework.Mvc.ModelBinding;
using Nop.Web.Framework.Models;

namespace Nop.Plugin.Misc.ApplicationInsights.Models
{
    public class ConfigurationModel : BaseNopModel
    {
        [NopResourceDisplayName("Plugins.Misc.ApplicationInsights.InstrumentationKey")]
        public string InstrumentationKey { get; set; }

        [NopResourceDisplayName("Plugins.Misc.ApplicationInsights.EnableQuickPulseMetricStream")]
        public bool EnableQuickPulseMetricStream { get; set; }

        [NopResourceDisplayName("Plugins.Misc.ApplicationInsights.EnableAdaptiveSampling")]
        public bool EnableAdaptiveSampling { get; set; }

        [NopResourceDisplayName("Plugins.Misc.ApplicationInsights.EnableHeartbeat")]
        public bool EnableHeartbeat { get; set; }

        [NopResourceDisplayName("Plugins.Misc.ApplicationInsights.AddAutoCollectedMetricExtractor")]
        public bool AddAutoCollectedMetricExtractor { get; set; }
    }
}
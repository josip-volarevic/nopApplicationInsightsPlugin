using Nop.Web.Framework.Mvc.ModelBinding;
using Nop.Web.Framework.Models;

namespace Nop.Plugin.Misc.ApplicationInsights.Models
{
    public class ConfigurationModel : BaseNopModel
    {
        [NopResourceDisplayName("Plugins.Misc.ApplicationInsights.InstrumentationKey")]
        public string InstrumentationKey { get; set; }
    }
}
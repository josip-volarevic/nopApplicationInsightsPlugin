using Microsoft.AspNetCore.Mvc;
using Nop.Core;
using Nop.Services.Configuration;
using Nop.Services.Localization;
using Nop.Web.Framework;
using Nop.Web.Framework.Controllers;
using Nop.Web.Framework.Mvc.Filters;
using Nop.Plugin.Misc.ApplicationInsights.Models;
using Microsoft.Extensions.Configuration;
using System.IO;
using Nop.Plugin.Misc.ApplicationInsights.Infrastructure;
using Nop.Services.Messages;

namespace Nop.Plugin.Misc.ApplicationInsights.Controllers
{
    public class MiscApplicationInsightsController : BasePluginController
    {
        #region Fields

        private readonly ILocalizationService _localizationService;
        private readonly INotificationService _notificationService;
        private readonly ISettingService _settingService;

        #endregion

        #region Ctor

        public MiscApplicationInsightsController(ISettingService settingService,
            INotificationService notificationService,
            ILocalizationService localizationService) 
        {
            this._settingService = settingService;
            this._notificationService = notificationService;
            this._localizationService = localizationService;
        }

        #endregion

        #region Methods

        [AuthorizeAdmin] //confirms access to the admin panel
        [Area(AreaNames.Admin)] //specifies the area containing a controller or action
        public IActionResult Configure()
        {
            // Extract the instrumentation key value from appsettings.json
            var config = new ConfigurationBuilder()
                .SetBasePath(GetConfigDirectory())
                .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
                .Build();
            var instrumentationKey = config["ApplicationInsights:InstrumentationKey"];

            var model = new ConfigurationModel
            {
                InstrumentationKey = instrumentationKey
            };

            return View("~/Plugins/Misc.ApplicationInsights/Views/Configure.cshtml", model);
        }

        [HttpPost]
        [AdminAntiForgery]
        [AuthorizeAdmin]
        [Area(AreaNames.Admin)]
        public IActionResult Configure(ConfigurationModel model)
        {
            // String that represents the new JSON with an updated instrumentation key value from the model
            string appSettings = $"{{\n\t\"ApplicationInsights\": {{\n\t\t\"InstrumentationKey\": \"{model.InstrumentationKey}\"\n\t}}\n}}";

            // Overwrite appsettings.json file with the new JSONs
            System.IO.File.WriteAllText($"{GetConfigDirectory()}\\appsettings.json", appSettings);

            // Now clear settings cache
            _settingService.ClearCache();

            _notificationService.SuccessNotification(_localizationService.GetResource("Admin.Plugins.Saved"));

            return Configure();
        }

        private string GetConfigDirectory()
        {
            string assemblyPath = System.Reflection.Assembly.GetAssembly(typeof(PluginStartup)).Location;
            string pluginPath = Path.Combine(assemblyPath, @"..\..\Misc.ApplicationInsights");
            return Path.GetFullPath(pluginPath);
        }

        #endregion
    }
}
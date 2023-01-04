using Microsoft.AspNetCore.Mvc;
using Nop.Core;
using Nop.Plugin.Misc.ConnectApi.Integration;
using Nop.Plugin.Misc.ConnectApi.Models;
using Nop.Services.Configuration;
using Nop.Services.Localization;
using Nop.Services.Messages;
using Nop.Services.Security;
using Nop.Web.Framework.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ILogger = Nop.Services.Logging.ILogger;

namespace Nop.Plugin.Misc.ConnectApi.Controllers
{
    public class  HomeController: BasePluginController
    {
        #region Fields
        private readonly ISettingService _settingService;
        private readonly IStoreContext _storeContext;
        private readonly IPermissionService _permissionService;
        private readonly INotificationService _notificationService;
        private readonly ILocalizationService _localizationService;
        private readonly ILogger _logger;

        #endregion
        public HomeController(
           ISettingService settingService,
           IStoreContext storeContext,
           IPermissionService permissionService,
           INotificationService notificationService,
           ILocalizationService localizationService,
           ILogger logger
            )
        {
            _settingService = settingService;
            _storeContext = storeContext;
            _permissionService = permissionService;
            _notificationService = notificationService;
            _localizationService = localizationService;
            _logger = logger;

        }
        public virtual async Task<IActionResult> EmployeesList()
        {
            //load Api settings
            var storeScope = await _storeContext.GetActiveStoreScopeConfigurationAsync();
            var connectApiSettings = await _settingService.LoadSettingAsync<ConnectApiSettings>(storeScope);

            var allEmployees = new ConnectSampleApi(connectApiSettings, _logger).GetAllEmployees();
           
      

            return View("~/Plugins/Nop.Plugin.Misc.ConnectApi/Views/GetAllEmployees.cshtml", allEmployees);
        }

      
    }
}

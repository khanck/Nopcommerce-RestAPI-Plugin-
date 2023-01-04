using Nop.Core;
using Nop.Plugin.Misc.ConnectApi.Models;
using Nop.Plugin.Misc.ConnectApi.Services;
using Nop.Services.Cms;
using Nop.Services.Common;
using Nop.Services.Configuration;
using Nop.Services.Localization;
using Nop.Services.Plugins;
using Nop.Services.Security;
using Nop.Web.Framework;
using Nop.Web.Framework.Infrastructure;
using Nop.Web.Framework.Menu;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Nop.Plugin.Misc.ConnectApi
{
    /// <summary>
    /// Rename this file and change to the correct type
    /// </summary>
    public class ConnectApiPlugin : BasePlugin, IMiscPlugin, IAdminMenuPlugin
    {
        #region Fields
        private readonly ISettingService _settingService;
        private readonly ILocalizationService _localizationService;
        private readonly IWebHelper _webHelper;
        private readonly IPermissionService _permissionService;
        private readonly IPermissionProvider _permissionProvider;
        private readonly IPluginManager<ConnectApiPlugin> _pluginManager;

        #endregion
        public ConnectApiPlugin(
            ISettingService settingService,
            ILocalizationService localizationService,
            IWebHelper webHelper,
            IPermissionService permissionService,
            IPluginManager<ConnectApiPlugin> pluginManager
            )
        {
            _settingService = settingService;
            _localizationService = localizationService;
            _webHelper = webHelper;
            _permissionService = permissionService;
            _permissionProvider = new ConnectApiPermissionProvider();
            _pluginManager = pluginManager;

        }
        public override async Task InstallAsync()
        {
            //settings
            var settings = new ConnectApiSettings()
            {
                ConnectApiEnabled = true
            };

            await _settingService.SaveSettingAsync(settings);

            //locales
            await _localizationService.AddOrUpdateLocaleResourceAsync(new Dictionary<string, string>
            {
                ["ConnectApi.Enabled"] = "ConnectApi Enabled",
                ["ConnectApi.ConnectApiApiUrl"] = "Api Url",
                ["ConnectApi.ConnectApiApiUser"] = "Api User Name",
                ["ConnectApi.ConnectApiApiPass"] = "Api Password",

                //menu 
                ["ConnectApi.ConnectApi"] = "API",
              

              

            });


            // permissions
            await _permissionService.InstallPermissionsAsync(_permissionProvider);

            await base.InstallAsync();
        }

        public override async Task UninstallAsync()
        {
            await _settingService.DeleteSettingAsync<ConnectApiSettings>();

            await _localizationService.DeleteLocaleResourcesAsync("ConnectApi");

            // permissions
            await _permissionService.UninstallPermissionsAsync(_permissionProvider);
            await base.UninstallAsync();
        }

        public override Task UpdateAsync(string currentVersion, string targetVersion)
        {
            return base.UpdateAsync(currentVersion, targetVersion);
        }

        public override string GetConfigurationPageUrl()
        {
            return $"{_webHelper.GetStoreLocation()}Admin/ConnectApi/Configure";
        }

        public async Task ManageSiteMapAsync(SiteMapNode rootNode)
        {
            var pl = _pluginManager.LoadAllPluginsAsync();

            if (!_pluginManager.IsPluginActive(this, new List<string> { ConnectApiDefaults.PluginSystemName }))
                return;

            if (
                !await _permissionService.AuthorizeAsync(ConnectApiPermissionProvider.ManageConnectApiPlugin) &&
                !await _permissionService.AuthorizeAsync(ConnectApiPermissionProvider.ManageConnectApi))
                return;

           
        }


    }
}

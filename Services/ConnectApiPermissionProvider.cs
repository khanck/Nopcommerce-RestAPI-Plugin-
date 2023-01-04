using Nop.Core.Domain.Customers;
using Nop.Core.Domain.Security;
using Nop.Services.Security;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nop.Plugin.Misc.ConnectApi.Services
{
    public partial class ConnectApiPermissionProvider : IPermissionProvider
    {
        //admin area permissions
        public static readonly PermissionRecord ManageConnectApiPlugin = new() { Name = "Connect Api. Manage Plugin", SystemName = "ManageConnectApiPlugin", Category = "Standard" };
        public static readonly PermissionRecord ManageConnectApi = new() { Name = "Connect Api.Connect to api ", SystemName = "ManageConnectApiItems", Category = "Standard" };


        public HashSet<(string systemRoleName, PermissionRecord[] permissions)> GetDefaultPermissions()
        {
            return new HashSet<(string, PermissionRecord[])>
            {
                (
                    NopCustomerDefaults.AdministratorsRoleName,
                    new[]
                    {
                        ManageConnectApiPlugin,
                        ManageConnectApi
                    }
                )
            };
        }

        public IEnumerable<PermissionRecord> GetPermissions()
        {
            return new[]
            {
                ManageConnectApiPlugin,
                ManageConnectApi
            };
        }
    }
}

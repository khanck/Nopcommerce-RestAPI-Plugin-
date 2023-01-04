using Nop.Core.Configuration;
using Nop.Web.Framework.Mvc.ModelBinding;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nop.Plugin.Misc.ConnectApi.Models
{
    public class ConnectApiSettings: ISettings
    {
        [NopResourceDisplayName("ConnectApi.Enabled")]
        public bool ConnectApiEnabled { get; set; }
        [NopResourceDisplayName("ConnectApi.ApiUrl")]
        public string ConnectApiUrl { get; set; } = "https://dummy.restapiexample.com/api/v1/employees";

        [NopResourceDisplayName("ConnectApi.ApiUser")]
        public string ConnectApiUser { get; set; } = "admin";
        [NopResourceDisplayName("ConnectApi.ApiPass")]
        public string ConnectApiPass { get; set; } = "ApiPass";
    }
}

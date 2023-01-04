using Nop.Web.Framework.Models;
using Nop.Web.Framework.Mvc.ModelBinding;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nop.Plugin.Misc.ConnectApi.Models
{
    public record ConfigurationModel: BaseNopModel
    {
        public int ActiveStoreScopeConfiguration { get; set; }

        [NopResourceDisplayName("ConnectApi.Enabled")]
        public bool ConnectApiEnabled { get; set; }
        public bool ConnectApiEnabled_OverrideForStore { get; set; }

        [NopResourceDisplayName("ConnectApi.ConnectApiUrl")]
        public string ConnectApiUrl { get; set; }
        public bool ConnectApiUrl_OverrideForStore { get; set; }

        [NopResourceDisplayName("ConnectApi.ConnectApiUser")]
        public string ConnectApiUser { get; set; }
        public bool ConnectApiUser_OverrideForStore { get; set; }

        [NopResourceDisplayName("ConnectApi.ConnectApiPass")]
        public string ConnectApiPass { get; set; }
        public bool ConnectApiPass_OverrideForStore { get; set; }
    }
}

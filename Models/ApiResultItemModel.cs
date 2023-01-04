using Nop.Web.Framework.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nop.Plugin.Misc.ConnectApi.Models
{
    public partial record ApiResultItemModel : BaseNopEntityModel
    {
        public string employee_name { get; set; }
        public int employee_salary { get; set; }
        public int employee_age { get; set; }  
        public string profile_image { get; set; }
   
    }
}

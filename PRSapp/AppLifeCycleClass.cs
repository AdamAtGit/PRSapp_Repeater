using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PRSapp
{
    public class AppLifeCycleClass
    {
        private int UserId { get; set; }
        bool IsLoggedOut { get; set; } //no activity bg timer?
        bool IsAppInBackground { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlockLaunch.Classes.JSON.Login.Refresh
{
    public class RefreshParameter
    {
        public bool Status { get; set; }
        public Error Error { get; set; }
        public RefreshResponse oRefreshResponse { get; set; }
    }
}

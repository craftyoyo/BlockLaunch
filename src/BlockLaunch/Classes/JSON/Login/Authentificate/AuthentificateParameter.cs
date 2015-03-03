using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BlockLaunch.Classes.JSON.Login.Authentificate;
using Newtonsoft.Json;

namespace BlockLaunch.Classes.JSON.Login
{
    public class AuthentificateParameter
    {
        public bool Status { get; set; }
        public Error Error { get; set; }
        public AuthentificationResponse AuthResponse { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WaterPoloStat.API.Dtos.Auth
{
    public class AppUserAuth
    {
        public string Id { get; set; }
        public string Username { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string BearerToken { get; set; }
        public bool IsAuthenticated { get; set; }
    }
}

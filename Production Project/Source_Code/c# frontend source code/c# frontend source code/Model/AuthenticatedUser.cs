using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnalyzeApp.Model
{
    public class AuthenticatedUser
    {
        public AuthenticatedUser(string UserName, string Password)
        {
            userName = UserName;
            userPassword = Password;
        }
        public string userName { set; get; }
        public string userPassword { set; get; }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnalyzeApp.Model
{
    public class UserModel
    {
        public UserModel(string userName, string userEmail, string userPassword, string userRole, int accountStatus)
        {
            this.userName = userName;
            this.userEmail = userEmail;
            this.userPassword = userPassword;
            this.userRole = userRole;
            this.accountStatus = accountStatus;

        }
        public string userName { set; get; }
        public string userEmail { set; get; }
        public string userPassword { set; get; }
        public string userRole { set; get; }
        public int accountStatus { set; get; }
    }
}

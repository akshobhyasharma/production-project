using AnalyzeApp.Model;
using AnalyzeApp.Request;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnalyzeApp.Store
{
    public class UserStore
    {

        private AuthenticatedUser userCredentials;

        public AuthenticatedUser UserCredentials
        {
            get { return userCredentials; }
            set { userCredentials= value; }
        }

        private int _userID;

        public int UserID
        {
            get { return _userID; }
            set { _userID = value; }
        }
    }
}

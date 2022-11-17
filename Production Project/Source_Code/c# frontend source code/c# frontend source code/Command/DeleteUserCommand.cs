using AnalyzeApp.Request;
using AnalyzeApp.Services;
using AnalyzeApp.Store;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnalyzeApp.Command
{
    class DeleteUserCommand : BaseAsyncCommand
    {
        private UserStore userStore;
        private NavigationService navigationServiceIndex;
        private apiReq request = new apiReq();

        public DeleteUserCommand(UserStore userStore, NavigationService navigationServiceIndex)
        {
            this.userStore = userStore;
            this.navigationServiceIndex = navigationServiceIndex;
        }

        public override async Task ExecuteAsync(object? parameter)
        {
            try
            {
                var result = await request.DeleteUser(userStore.UserID);
                if ((int)result.StatusCode == 200)
                {
                    navigationServiceIndex.Navigate();
                }
            }
            catch(Exception ex)
            {
                
            }
        }
    }
}

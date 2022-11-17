using AnalyzeApp.Model;
using AnalyzeApp.Request;
using AnalyzeApp.Store;
using AnalyzeApp.ViewModel;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace AnalyzeApp.Command
{
    class SpliceCommand : BaseAsyncCommand
    {
        private UserStore userStore;
        private VideoAnalyzeViewModel videoAnalyzeViewModel;
        private apiReq request = new apiReq();

        public SpliceCommand(UserStore userStore, VideoAnalyzeViewModel videoAnalyzeViewModel)
        {
            this.userStore = userStore;
            this.videoAnalyzeViewModel = videoAnalyzeViewModel;
        }

        public override async Task ExecuteAsync(object? parameter)
        {
            videoAnalyzeViewModel.IsLoading = true;
            try
            {
                var currentVid = videoAnalyzeViewModel.SelectedVideo;
                bool validFlag = true;
                if (currentVid is null)
                {
                    validFlag = false;
                    videoAnalyzeViewModel.SpliceMessage = "Please select a video.";
                }
                if (videoAnalyzeViewModel.BikeChecked == false && videoAnalyzeViewModel.CarChecked == false && videoAnalyzeViewModel.BusChecked == false && videoAnalyzeViewModel.TruckChecked == false && videoAnalyzeViewModel.PersonChecked == false)
                {
                    validFlag = false;
                    videoAnalyzeViewModel.SpliceMessage = "Pick one object.";
                }
                if (validFlag == true)
                {
                    videoAnalyzeViewModel.SpliceMessage = "Analyzing Video";
                    var parameters = returnTrueList();
                    var result = await request.postSplice(currentVid.videoName, returnCheckedValue(), parameters);
                    if ((int)result.StatusCode == 200)
                    {
                        string parseContent = await result.Content.ReadAsStringAsync();
                        string deserializeAgain = JsonConvert.DeserializeObject(parseContent).ToString();
                        var parsedJson = Newtonsoft.Json.JsonConvert.DeserializeObject<Dictionary<int, SpliceRecieved>>(deserializeAgain);
                        if (parsedJson.Count > 0)
                        {
                            videoAnalyzeViewModel.SpliceMessage = "Splicing Video";
                            Task openPortTask = Task.Run(() => request.listener(parsedJson));
                            Task requestVidTask = Task.Run(async ()=>{
                                await Task.Delay(1);
                                request.getVideo(); 
                            });
                            await Task.WhenAll(openPortTask, requestVidTask);
                            videoAnalyzeViewModel.SpliceMessage = "Videos recieved";

                            videoAnalyzeViewModel.RecievedVideoCollection.Clear();

                            foreach(KeyValuePair<int, SpliceRecieved> entry in parsedJson)
                            {
                                videoAnalyzeViewModel.RecievedVideoCollection.Add(entry.Value);
                            }


                            videoAnalyzeViewModel.SelectedSplice = videoAnalyzeViewModel.RecievedVideoCollection.First();
                        }
                        else
                        {
                            videoAnalyzeViewModel.SpliceMessage = "No splice detected";
                        }
                    }
                }
            }
            catch(Exception ex)
            {
                var message = "some error occurred.";
            }
            videoAnalyzeViewModel.IsLoading = false;

        }

        public List<String> returnTrueList()
        {
            List<String> parameterList = new List<String>();
            if (videoAnalyzeViewModel.BikeChecked == true)
            {
                parameterList.Add("motorcycle");
            }
            if (videoAnalyzeViewModel.BusChecked == true)
            {
                parameterList.Add("bus");
            }
            if (videoAnalyzeViewModel.CarChecked == true)
            {
                parameterList.Add("car");
            }
            if (videoAnalyzeViewModel.TruckChecked == true)
            {
                parameterList.Add("truck");
            }
            if (videoAnalyzeViewModel.PersonChecked == true)
            {
                parameterList.Add("person");
            }
            return parameterList;
        }

        public String returnCheckedValue()
        {
            string checkedValue = "normal";
            if (videoAnalyzeViewModel.QuickChecked == true)
            {
                checkedValue = "flash";
            }
            if (videoAnalyzeViewModel.AverageChecked == true)
            {
                checkedValue = "fast";
            }
            if (videoAnalyzeViewModel.DetailedChecked == true)
            {
                checkedValue = "normal";
            }
            return checkedValue;
        }
    }
}

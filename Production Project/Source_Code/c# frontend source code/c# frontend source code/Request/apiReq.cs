using AnalyzeApp.Model;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace AnalyzeApp.Request
{
    class apiReq
    {
        HttpClient client = new HttpClient();
        public async Task<String> getAllVideo(int userID)
        {
            var URL = new Uri("http://127.0.0.1:5000/userVid/" + userID);
            var result =await client.GetAsync(URL);
            string stringContent = await result.Content.ReadAsStringAsync();
            return stringContent;
        }

        public async Task<String> getUserInfo(int userID)
        {
            var URL = new Uri("http://127.0.0.1:5000/userInfo/" + userID);
            var result = await client.GetAsync(URL);
            string stringContent = await result.Content.ReadAsStringAsync();
            return stringContent;
        }

        public string checkUser(String userName, String Password)
        {
            var URL = new Uri("http://127.0.0.1:5000/authenticate");

            var authenticate = new AuthenticatedUser(userName, Password);
            var convertJson = JsonConvert.SerializeObject(authenticate);
            var payload = new StringContent(convertJson, Encoding.UTF8, "application/json");
            var result = client.PostAsync(URL, payload).Result.Content.ReadAsStringAsync().Result;
            return result;
        }

        public string checkUsername(String userName, String Email)
        {
            var URL = new Uri("http://127.0.0.1:5000/checkUser");
            Dictionary<String, String> values = new Dictionary<string, string>();
            values.Add("userName", userName);
            values.Add("userEmail", Email);
            var convertJson = JsonConvert.SerializeObject(values);
            var payload = new StringContent(convertJson, Encoding.UTF8, "application/json");
            var result = client.PostAsync(URL, payload).Result.Content.ReadAsStringAsync().Result;
            return result;
        }

        public async Task<String> checkVideo(String videoName)
        {
            var URL = new Uri("http://127.0.0.1:5000/checkVideo");
            Dictionary<String, String> values = new Dictionary<string, string>();
            values.Add("videoName", videoName);
            var ConvertJson = JsonConvert.SerializeObject(values);
            var payload = new StringContent(ConvertJson, Encoding.UTF8, "application/json");
            var result = await client.PostAsync(URL, payload).Result.Content.ReadAsStringAsync();
            return result;
        }

        public string postUser(string userName, string userEmail, string userPassword, string userRole, int accountStatus)
        {
            var URL = new Uri("http://127.0.0.1:5000/user");
            UserModel user = new UserModel(userName, userEmail, userPassword, userRole, accountStatus);

            var convertJson = JsonConvert.SerializeObject(user);
            var payload = new StringContent(convertJson, Encoding.UTF8, "application/json");
            var result = client.PostAsync(URL, payload).Result.Content.ReadAsStringAsync().Result;
            return result;
        }

        public string getVideo(int videoID)
        {
            var URL = new Uri("http://127.0.0.1:5000/video/" + videoID);
            var result = client.GetAsync(URL).Result;
            string json = result.Content.ReadAsStringAsync().Result;
            return json;
        }
        public async Task<HttpResponseMessage> deleteVideo(int videoID)
        {
            var URL = new Uri("http://127.0.0.1:5000/video/" + videoID);
            var result = await client.DeleteAsync(URL);
            return result;
        }

        public async Task<HttpResponseMessage> postVideo(VideoModel videoModel)
        {
            var URL = new Uri("http://127.0.0.1:5000/video");
            var convertJson = JsonConvert.SerializeObject(videoModel);
            var payLoad = new StringContent(convertJson, Encoding.UTF8, "application/json");
            var result = await client.PostAsync(URL, payLoad);
            return result;
        }

        public async Task<HttpResponseMessage> updateVideo(VideoModel videoModel)
        {
            var URL = new Uri("http://127.0.0.1:5000/video");
            var videoInstance = videoModel;
            var convertJson = JsonConvert.SerializeObject(videoInstance);
            var payload = new StringContent(convertJson, Encoding.UTF8, "application/json");
            var result = await client.PutAsync(URL, payload);
            return result;
        }

        public async Task<HttpResponseMessage> UpdateUserInfo(int userID, String userName, string email)
        {
            var URL = new Uri("http://127.0.0.1:5000/infoChange");
            var userInfo = new Dictionary<String, Object>();
            userInfo.Add("userID", userID);
            userInfo.Add("userName", userName);
            userInfo.Add("userEmail", email);
            var convertJson = JsonConvert.SerializeObject(userInfo);
            var payload = new StringContent(convertJson, Encoding.UTF8, "application/json");
            var result = await client.PostAsync(URL, payload);
            return result;
        }

        public async Task<HttpResponseMessage> UpdateUserPassword(int userID, string password)
        {
            var URL = new Uri("http://127.0.0.1:5000/passwordChange");
            var userInfo = new Dictionary<String, object>();
            userInfo.Add("userID", userID);
            userInfo.Add("userPassword", password);
            var convertJson = JsonConvert.SerializeObject(userInfo);
            var payload = new StringContent(convertJson, Encoding.UTF8, "application/json");
            var result = await client.PostAsync(URL, payload);
            return result;
        }

        public async Task<HttpResponseMessage> DeleteUser(int userID)
        {
            var URL = new Uri("http://127.0.0.1:5000/userDelete/"+userID);
            var result = await client.DeleteAsync(URL);
            return result;
        }

        public string sendVideo(string filePath, string videoName, string userName, string password)
        {
            IPAddress address = IPAddress.Parse("127.0.0.1");
            IPEndPoint ipe = new IPEndPoint(address, 8848);
            Socket client = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            client.Connect(ipe);

            double length = new System.IO.FileInfo(filePath).Length;
            string fileLength = length.ToString() + "\n";

            string preParameters = videoName + "\n" + fileLength + userName +"\n"+password+"\n";

            byte[] preBuffer = Encoding.Default.GetBytes(preParameters);
            byte[] postbuffer = Encoding.Default.GetBytes("File transferred.");

            client.SendFile(filePath, preBuffer, postbuffer, TransmitFileOptions.UseDefaultWorkerThread);
            client.Shutdown(SocketShutdown.Both);
            client.Close();
            return "Completed";
        }

        public async Task<HttpResponseMessage> postSplice(string videoName, string pace, List<String> list)
        {
            var URL = new Uri("http://127.0.0.1:5000/spliceFile");
            var spliceInstance = new Splice(pace, videoName, list);
            var convertJson = JsonConvert.SerializeObject(spliceInstance);
            var payLoad = new StringContent(convertJson, Encoding.UTF8, "application/json");
            Console.WriteLine(payLoad);
            var result = await client.PostAsync(URL, payLoad);
            return result;
        }

        public async Task getVideo()
        {
            var URL = new Uri("http://127.0.0.1:5000/spliceReq");
            var result = await client.GetAsync(URL);
        }

        public void listener(Dictionary<int,SpliceRecieved>? spliceDictionary)
        {
            TcpListener? server = null;
            try
            {
                int port = 13000;
                IPAddress localAddr = IPAddress.Parse("127.0.0.1");

                server = new TcpListener(localAddr, port);
                server.Start();

                Byte[] bytes = new Byte[10000];
                int length = 0;
                while (length< spliceDictionary.Count)
                {
                    TcpClient client = server.AcceptTcpClient();
                    NetworkStream stream = client.GetStream();
                    Directory.CreateDirectory("./SavedVideo");
                    string path = "./SavedVideo/"+ spliceDictionary[length].spliceName;
                    Stream fileStream = new FileStream(path, FileMode.Create);
                    BinaryWriter bw = new BinaryWriter(fileStream);

                    int i;

                    while ((i = stream.Read(bytes, 0, bytes.Length)) != 0)
                    {

                        bw.Write(bytes);
                    }

                    stream.Close();
                    fileStream.Close();
                    bw.Close();
                    client.Close();
                    length++;
                }
            }
            catch (SocketException e)
            {
                Console.WriteLine("SocketExcpetion:{0}", e);
            }
            finally
            {
                server.Stop();
            }
        }
    }
}

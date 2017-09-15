using System;

using System.IO;
using System.Net;
using Newtonsoft.Json;
using System.Threading.Tasks;
using System.Diagnostics;
using Xamarin.Forms;


namespace TheForum
{
    public class UserWebRequest
    {
		private static string url = "http://introtoapps.com/datastore.php?appid=214078374";
		public string username;
		public string password;

		public static UserWebRequest CreateUserFromJson(string json)
		{
			UserWebRequest afterJson = JsonConvert.DeserializeObject<UserWebRequest>(json);
			return afterJson;
		}


		public string ToJsonString()
		{
			return JsonConvert.SerializeObject(this);

		}

		public UserWebRequest()
		{

		}

		public UserWebRequest(string username)
		{
			this.username = username;
		}

		public UserWebRequest(string username, string password)
		{
			this.username = username;
			this.password = password;
		}
     
		public async void Save()
		{
			try
			{
                string jsonString = this.ToJsonString();
                jsonString = WebUtility.UrlEncode(jsonString);

				string actualUrl = url + "&action=save&objectid=" + username + ".user" + "&data=" + jsonString;

				Uri uri = new Uri(actualUrl);
				WebRequest request = WebRequest.Create(uri);
				request.Method = "GET";

                await GetServerResponse(request);
			}
			catch (Exception e)
			{
				Debug.WriteLine(e);
			}

		}

        public async void SendPost(string post)
        {
			try
			{
				string actualUrl = url + "&action=append&objectid=car"  + ".topic" + "&data=" + post;

				Uri uri = new Uri(actualUrl);
				WebRequest request = WebRequest.Create(uri);
				request.Method = "GET";

				await GetServerResponse(request);
			}
			catch (Exception e)
			{
				Debug.WriteLine(e);
			}
        }

        public async Task<string>GetPost()
        {
			try
			{
                string actualUrl = url + "&action=load&objectid=car" + ".topic";

				Uri uri = new Uri(actualUrl);
				WebRequest request = WebRequest.Create(uri);
				request.Method = "GET";

			    string result =	await GetServerResponse(request);
                return result;
			}
			catch (Exception e)
			{
				Debug.WriteLine(e);
                return null;
			}
        }


        public static async Task<UserWebRequest> Load(string username)
		{
			try
			{
				string requestURL = url + "&action=load&objectid=" + username + ".user";
				Uri uri = new Uri(requestURL);
                WebRequest request =  WebRequest.Create(uri);
				request.Method = "GET";

                string result = await GetServerResponse(request);

                return CreateUserFromJson(result);
			}
			catch (Exception e)
			{
				Debug.WriteLine(e);
				return null;
			}
		}

        public static async Task<string> GetServerResponse (WebRequest request)
        {
            string result = "";

			using (WebResponse response = await request.GetResponseAsync())
			{
				using (Stream stream = response.GetResponseStream())
				{
					StreamReader objStream = new StreamReader(stream);
					string sLine = "";
					while (sLine != null)
					{
						sLine = objStream.ReadLine();

						if (sLine != null)
                            
						    Debug.WriteLine(sLine);
                            result += sLine + "\n";
					}
				}
			}

            return result;
        }
    }
}
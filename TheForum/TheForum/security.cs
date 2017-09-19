using System;

using System.Text;
using System.IO;
using System.Net;
using Newtonsoft.Json;
using System.Threading.Tasks;
using System.Diagnostics;
using Xamarin.Forms;

namespace TheForum
{
    public class security : ContentPage
    {

		/*//security SHA
		public string SHA256Hash(string input)
		{
			byte[] sign_byte = Encoding.UTF8.GetBytes(input);
			var sha2 = SHA256.Create();
			sign_byte = sha2.ComputeHash(sign_byte);
			return Encoding.UTF8.GetString(sign_byte);
		}*/
        public security()
        {


			
		 


			Content = new StackLayout
            {
                Children = {
                    new Label { Text = "Hello ContentPage" }
                }
            };
        }
    }
}


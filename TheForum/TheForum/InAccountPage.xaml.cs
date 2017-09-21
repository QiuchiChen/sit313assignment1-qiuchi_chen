using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace TheForum
{
    public partial class InAccountPage : ContentPage
    {
        Label hint,nameText;
        Entry titleEntry;
        Editor bodyEntry;

        public InAccountPage(string TitleName)

        {
            
            InitializeComponent();
            BackgroundColor = Color.Black;
            hint = new Label
			{
				Text = "Enter the title and body then press post!!",
				TextColor = Color.White,
				BackgroundColor = Color.Silver,

			};
            nameText = new Label
            {
                Text = "qiuchi",
                TextColor = Color.NavajoWhite
            };
            nameText.SetBinding(Label.TextProperty,"Name");

            //make the entry to enter the titile of new post
            titleEntry = new Entry
            { 
                Placeholder = "Title"
            };
            titleEntry.SetBinding(Entry.TextProperty,"Title");
            //make the entry to enter the body of the new post (as editor)
            bodyEntry = new Editor
            {
                HeightRequest = 238
            };
            bodyEntry.SetBinding(Entry.TextProperty, "Body");

            // post button create
			Button PostButton = new Button
			{
				Text = "Post",
				TextColor = Color.White,
                BackgroundColor = Color.Silver,
				FontSize = 20,
				FontAttributes = FontAttributes.Bold,
				HorizontalOptions = LayoutOptions.FillAndExpand
			};
            // function on post button
			PostButton.Clicked += newpost;

            //webrequest of sending to sevier
			async void newpost(object sender, EventArgs e)
			{
                string title = titleEntry.Text;
                string body = bodyEntry.Text;

				List<Items> items = new List<Items>();

				DataTable data = await App.Database.LoadUser();
				string user = data.username;

                UserWebRequest request = new UserWebRequest();
                string afterRequest = await request.GetPost(TitleName);
                string checkUserPost = await request.GetPost(user);
                Items item = new Items(title , body, user);
                items.Add(item);
                JsonString jstring = new JsonString();

                if(afterRequest != null){
                    
                    string post = jstring.ToJsonString(item);
                    request.SendPost(post,TitleName);
                
                }else{
					
					string list = jstring.ConvertToJson(items);
					request.SendPost(list, TitleName);

                }

                if(checkUserPost != null){
                   
                    string post = jstring.ToJsonString(item);
					request.savePost(user, post);
                }else{
                    string list = jstring.ConvertToJson(items);
                    request.savePost(user, list);
                }


                // navaigation control after the post 
				await Navigation.PushModalAsync(new NavigationPage(new TabbedPage()

				{
                    BindingContext = new DataTable(),
					Children = {
                        new TheForumPage (){ BindingContext = new DataTable()},

                        new settings(){ BindingContext = new DataTable() },

				}
				}));

			
			}
			Content = new StackLayout
			{
				Padding = 30,
				Spacing = 30,
                Children = { hint,nameText,titleEntry,bodyEntry, PostButton }
			};
		}
    }
}

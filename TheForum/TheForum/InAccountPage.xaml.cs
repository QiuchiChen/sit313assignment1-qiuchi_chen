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
                Text = "qiuchi"
            };
            nameText.SetBinding(Label.TextProperty,"Name");


            titleEntry = new Entry
            { 
                Placeholder = "Title"
            };
            titleEntry.SetBinding(Entry.TextProperty,"Title");

            bodyEntry = new Editor
            {
                HeightRequest = 238
            };
            bodyEntry.SetBinding(Entry.TextProperty, "Body");


			Button PostButton = new Button
			{
				Text = "Post",
				TextColor = Color.White,
                BackgroundColor = Color.Silver,
				FontSize = 20,
				FontAttributes = FontAttributes.Bold,
				HorizontalOptions = LayoutOptions.FillAndExpand
			};
			PostButton.Clicked += newpost;

			async void newpost(object sender, EventArgs e)
			{
                string title = titleEntry.Text;
                string body = bodyEntry.Text;


                UserWebRequest request = new UserWebRequest();
                string afterRequest = await request.GetPost(TitleName);

                DataTable data = await App.Database.LoadUser();
                string user = data.username;

                Items item = new Items(title , body, user);

                JsonString jstring = new JsonString();

                if(afterRequest != null){
                    
                    string post = jstring.ToJsonString(item);
                    request.SendPost(post,TitleName);
                }else{
				
					List<Items> items = new List<Items>();
					items.Add(item);
					string list = jstring.ConvertToJson(items);
					request.SendPost(list, TitleName);
                }

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

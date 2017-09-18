using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace TheForum
{
    public partial class InAccountPage : ContentPage
    {
        Label hint,nameText;
        Entry titleEntry, bodyEntry;

        public InAccountPage()

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

            bodyEntry = new Entry
            {
                Placeholder = "Body"
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
                string afterRequest = await request.GetPost();
                Items item = new Items(title , body,"qiuchi");
                JsonString jstring = new JsonString();

                if(afterRequest != null){
                    
                    string post = jstring.ToJsonString(item);
                    request.SendPost(post);
                }else{
				
					List<Items> items = new List<Items>();
					items.Add(item);
					string list = jstring.ConvertToJson(items);
					request.SendPost(list);
                }

				await Navigation.PushModalAsync(new NavigationPage(new TabbedPage()

				{
					Children = {
					 new TheForumPage (),

					new settings(),

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

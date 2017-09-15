using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace TheForum
{
    public partial class InAccountPage : ContentPage
    {
        Label nameText;
        Entry titleEntry, bodyEntry;

        public InAccountPage()
        {
            InitializeComponent();
            BackgroundColor = Color.Black;

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


   //         var table = new TableView
   //         {
   //             BackgroundColor = Color.White,
   //             Intent = TableIntent.Form,

   //             Root = new TableRoot("Table Title") {
   //                 new TableSection ("User&title") {

   //                  new TextCell (){
   //                         Detail = "Name",
   //                         Text = "admin",

   //                         TextColor = Color.NavajoWhite
			//			},
			//		new EntryCell {
			//				Label = "Title:",
			//				Placeholder = "Enter the title here",
			//				Keyboard = Keyboard.Default
			//			}
			//		},
			//		new TableSection ("Main Body") {
			//		new EntryCell {
			//				Label = "Body:",
			//				Placeholder = "Enter the body here",
			//				Keyboard = Keyboard.Telephone
			//			},
						
			//		}
			//	}
			//};


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

                Items item = new Items(title , body,"qiuchi");
                JsonString jstring = new JsonString();
                List<Items> items = new List<Items>();
                items.Add(item);
                string list = jstring.ConvertToJson(items);
                UserWebRequest request = new UserWebRequest();


                request.SendPost(list);


				await Navigation.PushModalAsync(new NavigationPage(new TabbedPage()

				{
					Children = {
					 new TheForumPage (),
                     //new LoginPage() ,
                   
                    new settings(),

				}
				}));
			}
			Content = new StackLayout
			{
				Padding = 30,
				Spacing = 30,
                Children = { nameText,titleEntry,bodyEntry, PostButton }
			};
		}
    }
}

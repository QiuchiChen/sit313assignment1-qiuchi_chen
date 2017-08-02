using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace TheForum
{
    public partial class InAccountPage : ContentPage
    {
        public InAccountPage()
        {
            InitializeComponent();
            BackgroundColor = Color.Black;
           
            var table = new TableView
            {

                BackgroundColor = Color.White,
                Intent = TableIntent.Form,


                Root = new TableRoot("Table Title") {
                    new TableSection ("User&title") {
                        
                        new TextCell {
                            Detail = "Name",
                            Text = "admin",

                            TextColor = Color.NavajoWhite
						},
						new EntryCell {
							Label = "Title:",
							Placeholder = "Enter the title here",
							Keyboard = Keyboard.Default
						}
					},
					new TableSection ("Main Body") {
						new EntryCell {
							Label = "Body:",
							Placeholder = "Enter the body here",
							Keyboard = Keyboard.Telephone
						},
						
					}
				}
				

			};
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
				await Navigation.PushAsync(new NavigationPage(new TabbedPage()

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
                Children = { table, PostButton }
			};
		}
    }
}

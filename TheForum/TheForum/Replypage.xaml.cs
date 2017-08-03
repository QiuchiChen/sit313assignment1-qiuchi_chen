using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace TheForum
{
    public partial class Replypage : ContentPage
    {
        public Replypage()
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

                    new TableSection ("Comments") {
                        new EntryCell {
                            Label = "Comments:",
                            Placeholder = "Enter the Comments here",
                            Keyboard = Keyboard.Telephone
                        },

                    }
                }


                }
            };
			Button PostButton = new Button
			{
				Text = "Reply",
				TextColor = Color.White,
				BackgroundColor = Color.Silver,
				FontSize = 20,
				FontAttributes = FontAttributes.Bold,
				HorizontalOptions = LayoutOptions.FillAndExpand
			};
			PostButton.Clicked += REPLY;

			async void REPLY(object sender, EventArgs e)
			{
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
				Children = { table, PostButton }
			};
        }
    }
}

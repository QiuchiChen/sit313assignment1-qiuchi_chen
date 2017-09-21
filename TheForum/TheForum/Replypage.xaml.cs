using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace TheForum
{
    public partial class Replypage : ContentPage
    {
        Label showtitle, showbody;
        public Replypage()
        {
            InitializeComponent();
            BackgroundColor = Color.Black;


            showtitle = new Label
            {
				HorizontalOptions = LayoutOptions.Center,
				FontAttributes = FontAttributes.Bold,
                TextColor = Color.NavajoWhite,
				FontSize = 35
               
            };
            showtitle.SetBinding(Label.TextProperty, "Title");


            showbody = new Label
			{
                BackgroundColor = Color.White,
                TextColor = Color.Black,
				
			};
            showbody.SetBinding(Label.TextProperty, "Body");

			var table = new TableView
            {

                BackgroundColor = Color.White,
                Intent = TableIntent.Form,


                Root = new TableRoot("Table Title") {
                    new TableSection ("User&title") {

                        new TextCell {
                            Detail = "Name",
                            Text = "qiuchi",
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
                List<DataTable> list = await App.Database.GetItemsAsync();
				if (list.Count == 0)
				{

					await DisplayAlert("Error", "Reply before login", "Ok");
                }else
                await Navigation.PushModalAsync(new NavigationPage(new TabbedPage()

                {
                    BindingContext = new DataTable(),
                    Children = {
                     new TheForumPage (){ BindingContext = new DataTable() },
                     //new LoginPage() ,
                   
                    new settings(){ BindingContext = new DataTable() }


                }
                }));
            }
            Content = new StackLayout
            {
                Padding = 30,
                Spacing = 30,
                Children = { showtitle, showbody,table, PostButton }
            };
        }
    }
}

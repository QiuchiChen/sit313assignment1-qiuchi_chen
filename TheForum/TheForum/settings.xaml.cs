using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace TheForum
{
    public partial class settings : ContentPage
    {
        
        public settings()
        {
			InitializeComponent();

			Title = "User Center";
			BackgroundColor = Color.Black;


			Label TitleLabel = new Label
			{
				Text = "User Center",
				HorizontalOptions = LayoutOptions.Center,
				FontAttributes = FontAttributes.Bold,
				TextColor = Color.NavajoWhite,
				FontSize = 35

			};

            //create the New Post button
            Button NewpostButton = new Button
            {
				Text = "NewPost",
				TextColor = Color.White,
				BackgroundColor = Color.Silver,
				FontSize = 20,
				FontAttributes = FontAttributes.Bold,
				HorizontalOptions = LayoutOptions.FillAndExpand
            };
            NewpostButton.Clicked += Newpost;


		//Create logout button
			Button logoutButton = new Button
			{
				Text = "Logout",
				TextColor = Color.White,
                BackgroundColor = Color.Red,
				FontSize = 20,
				FontAttributes = FontAttributes.Bold,
				HorizontalOptions = LayoutOptions.FillAndExpand
			};
			logoutButton.Clicked += loggedout;



			//Fit all different views into the page
			Content = new StackLayout
			{
				Padding = 20,
				Spacing = 80,
                Children = { TitleLabel, NewpostButton,logoutButton   }
			};


			async void loggedout(object sender, EventArgs e)
			{
                await Navigation.PushModalAsync(new NavigationPage(new TabbedPage()

				{
					Children = {
					 new TheForumPage (),
					 new LoginPage() ,
                   
                    //new settings(),


                }
                }));
			}

			async void Newpost(object sender, EventArgs e)
			{
				await Navigation.PushAsync(new InAccountPage());
			}


		}
    }
}

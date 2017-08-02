
﻿using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;


namespace TheForum
{
    public partial class LoginPage : ContentPage
    {
		Entry username, password;

        public LoginPage()
        {
			InitializeComponent();
			Title = "LogIn";
            BackgroundColor = Color.Black;


			Label TitleLabel = new Label
			{
				Text = "Login to the Forum",
                HorizontalOptions = LayoutOptions.Center,
                FontAttributes = FontAttributes.Bold,
                TextColor = Color.NavajoWhite,FontSize = 35
				
				

			};

			//make the text input for username by enrty
			username = new Entry
			{
				Placeholder = "Username",HeightRequest = 35,
			};

			//make text input for password by create an enrty
			password = new Entry
			{
				Placeholder = "Password",HeightRequest = 35,
				IsPassword = true
			};


			//Make the inputbox as the backgroud for 2 text input entry
			Frame inputbox = new Frame
			{
                BackgroundColor = Color.White,
				HasShadow = false,

				//Make the view for inputbox
				Content = new StackLayout
				{
					Orientation = StackOrientation.Vertical,Spacing = 10,
					//Put the input texts into the inputbox
					Children = { username, password }
				}

			};

			////Create login button
			Button loginButton = new Button
			{
				Text = "Login",TextColor = Color.White,
                BackgroundColor = Color.Silver,
				FontSize = 20,FontAttributes = FontAttributes.Bold,
				HorizontalOptions = LayoutOptions.FillAndExpand
			};
			loginButton.Clicked += loggedIn;


			//Make the login button
			Button SignupButton = new Button
			{
				Text = "Do not have an account?",
				FontSize = 10,FontAttributes = FontAttributes.Bold,
                TextColor = Color.White,
				HorizontalOptions = LayoutOptions.FillAndExpand
			};

			SignupButton.Clicked += register;

			//Fit all different views into the page
			Content = new StackLayout
			{
				Padding = 20,
				Spacing = 80,
				Children = { TitleLabel, inputbox, loginButton, SignupButton }
			};

		}

		//Error check for the login input
		async void loggedIn(object sender, EventArgs e)
		{
            var user = "admin";
            var pass = "admin";

            if (user== username.Text && pass==password.Text)
			{   // Logged in and move to new page
                await DisplayAlert("Login sucsses", "Moving to the new page.", "Ok");
				await Navigation.PushModalAsync(new NavigationPage(new TabbedPage()

				{
					Children = {
					 new TheForumPage (),
                     new settings(),


                }
                }));
			}

			else
			{
				//Show Alert for error check
				await DisplayAlert("Login Failed", "You have entered incorrect username or password, Please try again.", "Ok");
			}
		}

		//Move to the RegisterPage
		async void register(object sender, EventArgs e)
		{  
			await Navigation.PushAsync(new RegisterPage());
		}

	
		

	}

	
}
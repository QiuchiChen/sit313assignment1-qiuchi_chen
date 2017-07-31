
﻿using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;


namespace TheForum
{
    public partial class LoginPage : ContentPage
    {
        

        public LoginPage()
        {
			InitializeComponent();
			Title = "Account";


			var layout = new StackLayout { Padding = 10 };

			





			


			var button = new Button
			{
                Text = "Login", TextColor = Color.White, BackgroundColor = Color.Black };

			layout.Children.Add(button);

			Content = new ScrollView { Content = layout };

			button.Clicked += showlogin;

			var username = new Entry
			{
				Placeholder = "user name "
			}; 
            //username.SetBinding(Entry.TextProperty, LoginViewModel.UsernamePropertyName);
			layout.Children.Add(username);

            var password = new Entry
            {
                Placeholder = "password",
                IsPassword = true
            };
			//password.SetBinding(Entry.TextProperty, LoginViewModel.PasswordPropertyName);
			layout.Children.Add(password);

			Content = new StackLayout
			{
				Children = { username, password, button }
			};
		}

		void showlogin(object sender, System.EventArgs e)
		{


			DisplayAlert("Sucsees!", "login complete", "Coooool");

		}
	}
}

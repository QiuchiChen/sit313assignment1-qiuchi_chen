﻿using System;
using System.Collections.Generic;

using Xamarin.Forms;


namespace TheForum
{
    public partial class LoginPage : ContentPage
    {
        

        public LoginPage()
        {
			InitializeComponent();
			Title = "Account";


			var button = new Button
			{
				Text = "Login"

			};

			button.Clicked += showlogin;

			var username = new Entry
			{
				Placeholder = "user name "
			};

            var password = new Entry
            {
                Placeholder = "password"
            };


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

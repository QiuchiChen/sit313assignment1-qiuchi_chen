using System;
using System.Collections.Generic;

using Xamarin.Forms;
using System.Diagnostics;

namespace TheForum
{
    public partial class RegisterPage : ContentPage
    {   Entry username, password;


        internal static bool isEmpty;
        
        public RegisterPage()
        {

            InitializeComponent();
            Title = "Sign Up For Free!";
            BackgroundColor = Color.Black;

			var label = new Label
			{
				Text = "Enter username & password then press signup!!",
                TextColor = Color.White,
				BackgroundColor = Color.Silver,

			};

			//make the text input for username by enrty
			username = new Entry
			{
				Placeholder = "Username",
				HeightRequest = 35,
			};

			//make text input for password by create an enrty
			password = new Entry
			{
				Placeholder = "Password",
				HeightRequest = 35,
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
					Orientation = StackOrientation.Vertical,
					Spacing = 10,
					//Put the input texts into the inputbox
					Children = { username, password }
				}

			};

			//make sign up button
			Button SignUpButton = new Button
			{
				Text = "Sign Up",
				TextColor = Color.White,
				BackgroundColor = Color.Silver,
				FontSize = 20,
				FontAttributes = FontAttributes.Bold,
				HorizontalOptions = LayoutOptions.FillAndExpand
			};
			SignUpButton.Clicked += signup;
			

			//Fit all different views into the page
			Content = new StackLayout
			{
				Padding = 20,
				Spacing = 80,
                Children = { label, inputbox, SignUpButton }
			};

		}

		//Error check for the signup input
		async void signup(object sender, EventArgs e)
		{
			
 

			if (isEmpty == true)
			{
				//Show Alert for error check
				await DisplayAlert("SignUp Failed", "The username or password can not be empty, Please try again.", "Ok");
			}

			else
			{
				
				// sign up done and moving to new page
				await DisplayAlert("Sign up sucsses", "Please sign in at the Login Page.", "Ok");


                UserWebRequest user = UserWebRequest.CreateUserFromJson("{\"username\":\"" + username.Text + "\", \"password\":\"" + password.Text + "\"}");
                user.Save();

                Debug.WriteLine(user);
                 

				await Navigation.PushModalAsync(new NavigationPage(new TabbedPage()

				{
					Children = {
					  new TheForumPage (),
					  new LoginPage() ,


				}
				}));
			}
		}

	}


}
using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace TheForum
{
    public partial class PostCategoryPage : ContentPage
    {
        public PostCategoryPage()
        {
			
			InitializeComponent();
			BackgroundColor = Color.Black;


			Label TitleLabel = new Label
			{
				Text = "Choose the category to post",
				HorizontalOptions = LayoutOptions.Center,
				FontAttributes = FontAttributes.Bold,
				TextColor = Color.NavajoWhite,
				FontSize = 25
			};

			//create the button for post on car
			Button CarpostButton = new Button
			{
				Text = "CAR",
				TextColor = Color.White,
				BackgroundColor = Color.Silver,
				FontSize = 20,
				FontAttributes = FontAttributes.Bold,
				HorizontalOptions = LayoutOptions.FillAndExpand
			};
			CarpostButton.Clicked += carpost;

			//create the button for post on game 
			Button GamepostButton = new Button
			{
				Text = "GAME",
				TextColor = Color.White,
				BackgroundColor = Color.Silver,
				FontSize = 20,
				FontAttributes = FontAttributes.Bold,
				HorizontalOptions = LayoutOptions.FillAndExpand
			};
			GamepostButton.Clicked += gamepost;

			//create the button for post on shopping 
			Button ShoppingpostButton = new Button
			{
				Text = "SHOPPING",
				TextColor = Color.White,
                BackgroundColor = Color.Silver,
				FontSize = 20,
				FontAttributes = FontAttributes.Bold,
				HorizontalOptions = LayoutOptions.FillAndExpand
			};
			ShoppingpostButton.Clicked += shoppingpost;



			//Fit all different views into the page
			Content = new StackLayout
			{
				Padding = 20,
				Spacing = 80,
                Children = { TitleLabel, CarpostButton, GamepostButton, ShoppingpostButton }
			};

			async void carpost(object sender, EventArgs e)
			{
				await Navigation.PushAsync(new InAccountPage("car"));
			}

			async void gamepost(object sender, EventArgs e)
			{
				await Navigation.PushAsync(new InAccountPage("game"));
			}

			async void shoppingpost(object sender, EventArgs e)
			{
				await Navigation.PushAsync(new InAccountPage("shopping"));
			}

		}
    }
}

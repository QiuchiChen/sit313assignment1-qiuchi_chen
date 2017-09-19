using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;
namespace TheForum
{
    public partial class TheForumPage : ContentPage
    {
        public TheForumPage()
		{
			InitializeComponent();


            Title = "Qiuchi`s Forum";
            BackgroundColor = Color.Black;

			var maintitle = new Frame
			{
                BackgroundColor = Color.Black,

				Content = new Label
				{
					Text = "Qiuchi`s Forum!",
                    TextColor = Color.NavajoWhite,
					FontSize = 30,

					HorizontalOptions = LayoutOptions.Center,
                    FontAttributes = FontAttributes.Bold,
                },
			};


			var label = new Label
			{
				Text = "First choose your classifiction!!",
                TextColor = Color.White,
                BackgroundColor = Color.Silver,
                                       
			};

			//Create car calss button
			Button cargroupbutton = new Button
			{
                Image ="car.png",
                BackgroundColor = Color.Silver,
                HorizontalOptions = LayoutOptions.Center,
                                          
			};

            cargroupbutton.Clicked += push;

			async void push(object sender, EventArgs e)
			{
                await Navigation.PushAsync(new ForumList("car") { BindingContext = new DataTable() });
			}



			//Create game calss button
			Button gamegroupbutton = new Button
			{
				Image = "steam.png",
				
                BackgroundColor = Color.Silver,
				
                HorizontalOptions = LayoutOptions.Center,

			};

			gamegroupbutton.Clicked += gamepush;

			async void gamepush(object sender, EventArgs e)
			{
				await Navigation.PushAsync(new ForumList("game") { BindingContext = new DataTable() });
			}



			//Create shopping calss button
			Button shoppinggroupbutton = new Button
			{
				Image = "shop.png",

                BackgroundColor = Color.Silver,

				HorizontalOptions = LayoutOptions.Center,

			};

			shoppinggroupbutton.Clicked += shoppingpush;

			async void shoppingpush(object sender, EventArgs e)
			{
				await Navigation.PushAsync(new ForumList("shopping") { BindingContext = new DataTable() });
			}



			Content = new StackLayout
			{
				
				Spacing = 10,
                Children = {maintitle, label, cargroupbutton, gamegroupbutton, shoppinggroupbutton }
			};

		}
	}
}

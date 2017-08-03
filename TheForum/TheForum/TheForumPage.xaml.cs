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
                await Navigation.PushAsync(new ForumList());
			}



			//Create game calss button
			Button gamegroupbutton = new Button
			{
				Image = "steam.png",
				
                BackgroundColor = Color.Silver,
				
                HorizontalOptions = LayoutOptions.Center,

			};

			gamegroupbutton.Clicked += push;


			//Create shopping calss button
			Button shoppinggroupbutton = new Button
			{
				Image = "shop.png",

                BackgroundColor = Color.Silver,

				HorizontalOptions = LayoutOptions.Center,

			};

			shoppinggroupbutton.Clicked += push;




			/*var tableview = new TableView
			{



				Root = new TableRoot(){
					   new TableSection("Zelda"){

						new TextCell {

							Text = "The Legend of Zelda!!!!",
							Detail ="The legend which brings ur dream alive!",
						},


						new TextCell {
							ClassId = "2",
							Text = "Zelda best game of the year",
							Detail ="80% of the switch user have got Zelda! ",

						},


						new TextCell {
							Text = "Zelda New meta!!",
							Detail ="WOW its cooooooooooooool",
						}
					}}
			};*/

			/*var tableview = new TableView();
			tableview.Intent = TableIntent.Settings;
			
         
			
            var layout = new StackLayout() { Orientation = StackOrientation.Horizontal };

        
            layout.Children.Add(new Button()
			{
                Image = "lol.png",
                VerticalOptions = LayoutOptions.Center,
                HorizontalOptions = LayoutOptions.EndAndExpand
			});

			

			var layout1 = new StackLayout() { Orientation = StackOrientation.Horizontal };


			layout1.Children.Add(new Button()
			{
				Image = "car.png",
                VerticalOptions = LayoutOptions.Center,
                HorizontalOptions = LayoutOptions.CenterAndExpand                               
			});




			tableview.Root = new TableRoot()
            {
                new TableSection("Games")
                {
                new ViewCell() {View = layout}
                },

				new TableSection("Car")
				{
				new ViewCell() {View = layout1}
				}

			
            };*/







			Content = new StackLayout
			{
				
				Spacing = 10,
                Children = {maintitle, label, cargroupbutton, gamegroupbutton, shoppinggroupbutton }
			};

		}
	}
}

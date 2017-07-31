﻿using Xamarin.Forms;

namespace TheForum
{
    public partial class TheForumPage : ContentPage
    {
        public TheForumPage()
		{
			InitializeComponent();

            Title = "Qiuchi`s Forum";


            BackgroundColor = Color.Black;

			Content = new Frame
			{


				Content = new Label
				{
					Text = "Qiuchi`s Forum!",
                    TextColor = Color.NavajoWhite,
					FontSize = 30,
					HorizontalOptions = LayoutOptions.Center,
                    FontAttributes = FontAttributes.Bold,
                },

                OutlineColor = Color.White,

				
			};


			var label = new Label
			{
				Text = "Welcome!! And have a good time!!",
                TextColor = Color.White,
                BackgroundColor = Color.Silver,
                                       
			};

			var tableview = new TableView
			{
				Root = new TableRoot(){
					new TableSection("Zelda"){
						new TextCell {
							Text = "The Legend of Zelda",
							Detail ="WOW its cooooooooooooool",
						}
				}

				}
			};



			Content = new StackLayout
			{
                Children = {Content, label, tableview }
			};

		}
	}
}

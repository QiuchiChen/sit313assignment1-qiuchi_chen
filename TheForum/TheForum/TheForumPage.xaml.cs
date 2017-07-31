﻿using Xamarin.Forms;

namespace TheForum
{
    public partial class TheForumPage : ContentPage
    {
        public TheForumPage()
		{
			InitializeComponent();

			Title = "Qiuchi`s Forum";

			Content = new Frame
			{
				Content = new Label { Text = "I'm Framous!" },
				OutlineColor = Color.Silver,
				VerticalOptions = LayoutOptions.CenterAndExpand,
				HorizontalOptions = LayoutOptions.Center
			};


			var label = new Label
			{
				Text = "Welcome!! And have a good time!!",
				TextColor = Color.NavajoWhite,
				BackgroundColor = Color.Black
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

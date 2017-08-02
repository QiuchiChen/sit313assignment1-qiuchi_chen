﻿using Xamarin.Forms;

namespace TheForum
{
    public partial class TheForumPage : ContentPage
    {
        public TheForumPage()
		{
			InitializeComponent();
            BackgroundColor = Color.Black;

            Title = "Qiuchi`s Forum";




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
			 };
			
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
                Children = {Content, label, tableview }
			};

		}
	}
}

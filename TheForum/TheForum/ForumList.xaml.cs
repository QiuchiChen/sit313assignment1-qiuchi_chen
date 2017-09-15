using System;
using System.Collections.Generic;
using System.Diagnostics;

using Xamarin.Forms;

namespace TheForum
{
    public partial class ForumList : ContentPage
    {
        ListView listView;

		public class CustomCell : ViewCell
		{
			public CustomCell()
			{
				//instantiate each of our views
				var image = new Image();
				StackLayout cellWrapper = new StackLayout();
				StackLayout horizontalLayout = new StackLayout();
				Label left = new Label();
				Label right = new Label();

				//set bindings
				left.SetBinding(Label.TextProperty, "Title");
				right.SetBinding(Label.TextProperty, "Body");
				image.SetBinding(Image.SourceProperty, "image");

				//Set properties for desired design
                cellWrapper.BackgroundColor = Color.Snow;
                horizontalLayout.Orientation = StackOrientation.Vertical;
                right.HorizontalOptions = LayoutOptions.Center;
                left.TextColor = Color.Black;
                right.TextColor = Color.Silver;

				//add views to the view hierarchy
				horizontalLayout.Children.Add(image);
				horizontalLayout.Children.Add(left);
				horizontalLayout.Children.Add(right);
				cellWrapper.Children.Add(horizontalLayout);
				View = cellWrapper;
			}
		}


        public ForumList()
        {
            InitializeComponent();

			var label = new Label
			{
				Text = "Click the Post to reply!",
                TextColor = Color.NavajoWhite,
                BackgroundColor = Color.Black,

			};





            listView = new ListView
            {
                BackgroundColor = Color.Snow,
                RowHeight = 60,
				ItemTemplate = new DataTemplate(typeof(CustomCell))
                    
		
            };

            listView.ItemSelected += topicDetails;

            Content = new StackLayout
            {
                BackgroundColor = Color.Snow,
                Children = {label, listView}
            };

        }

		protected override async void OnAppearing()
		{
			base.OnAppearing();
			UserWebRequest request = new UserWebRequest();
			string afterRequest = await request.GetPost();
			JsonString jstring = new JsonString();
            Debug.
			listView.ItemsSource = jstring.ConvertToList(afterRequest);
		}

        async  void topicDetails(object seneder, SelectedItemChangedEventArgs e){

			if (e.SelectedItem == null)
			{
				return; //ItemSelected is called on deselection, which results in SelectedItem being set to null
			}

            listView.SelectedItem = null;

			await DisplayAlert("Loading", "Moving to view the detail and reply", "Ok");
            await Navigation.PushAsync(new Replypage());
		}
    }
}

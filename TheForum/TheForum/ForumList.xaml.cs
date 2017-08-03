using System;
using System.Collections.Generic;

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
				left.SetBinding(Label.TextProperty, "title");
				right.SetBinding(Label.TextProperty, "detail");
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

            var topic = new[]{

                new {title="Hihihihihih",detail="ohhh"},
                new {title="Hihihihihi",detail="ohhh"},
                new {title="Hihihihi",detail="ohhh"},
                new {title="Hihihihihih",detail="ohhh"},
                new {title="Hhihihihi",detail="ohhh"},
                new {title="Hhidqwdqwdwqdqwd",detail="ohhh"},
                new {title="Hhihihihihi",detail="ohhh"},
                new {title="Hhiqwdqwdqwd",detail="ohhh"},
                new {title="Hhiqwdwqdqw",detail="ohhh"},
                new {title="Hhiasdsadsadsad",detail="ohhh"},
                new {title="Hhiadsdasdasdasd",detail="ohhh"},
                new {title="Hhiasdasdsa",detail="ohhh"},
                new {title="Hhiasdasds",detail="ohhh"}
                
            };



            listView = new ListView
            {
                BackgroundColor = Color.Snow,
                RowHeight = 60,
                ItemsSource = topic,
				ItemTemplate = new DataTemplate(typeof(CustomCell))
                    
		
            };

            listView.ItemSelected += topicDetails;

            Content = new StackLayout
            {
                BackgroundColor = Color.Snow,
                Children = {label, listView}
            };

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

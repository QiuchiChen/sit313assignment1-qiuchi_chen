using System;
using System.Collections.Generic;
using System.Diagnostics;
using Xamarin.Forms;

namespace TheForum
{
    public partial class UserListPage : ContentPage
    {
        
           
            ListView listView;

			public class CustomCell : ViewCell
		{
			public CustomCell()
			{
				//instantiate each of our views
				StackLayout cellWrapper = new StackLayout();
				StackLayout horizontalLayout = new StackLayout();
				Label left = new Label();
				Label right = new Label();

				//set bindings
				left.SetBinding(Label.TextProperty, "Title");
				right.SetBinding(Label.TextProperty, "Name");

				//Set properties for desired design
				cellWrapper.BackgroundColor = Color.Snow;
				horizontalLayout.Orientation = StackOrientation.Vertical;
				right.HorizontalOptions = LayoutOptions.Center;
				left.TextColor = Color.Black;
				right.TextColor = Color.Silver;

				//add views to the view hierarchy
				horizontalLayout.Children.Add(left);
				horizontalLayout.Children.Add(right);
				cellWrapper.Children.Add(horizontalLayout);
				View = cellWrapper;
			}
		
        }





    }
}

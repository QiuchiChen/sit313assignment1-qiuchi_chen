using System;
using System.Collections.Generic;
using System.Diagnostics;
using Xamarin.Forms;

namespace TheForum
{
    public partial class UserListPage : ContentPage
    {

		ListView listView;
        Label usernamelabel;

		public string formName { get; set; }

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


		public async void LoadData(string UserTitle)
		{
			//Load the json from datastore
			UserWebRequest request = new UserWebRequest();
			string afterRequest = await request.GetPost(UserTitle);
			//Json convert to list
			JsonString jstring = new JsonString();

			if (afterRequest == null)
			{

			}
			else
			{
				//Add to listview
				listView.ItemsSource = jstring.ConvertToList(afterRequest);

			}



		}
        //get user name for per user list
        public UserListPage(string UserTitle)
		{
			LoadData(UserTitle);
			usernamelabel = new Label
			{
				HorizontalOptions = LayoutOptions.Center,
				FontAttributes = FontAttributes.Bold,
				TextColor = Color.Black,
				FontSize = 30
			};

			usernamelabel.Text = UserTitle;



			var label = new Label
			{
				Text = "Click the Post to reply!",
				TextColor = Color.NavajoWhite,
				BackgroundColor = Color.Black,

			};

			//var topic = new[]{

			//    new {Title="Hihihihihih",Name="ohhh"}

			//};



			listView = new ListView
			{
				BackgroundColor = Color.Snow,
				RowHeight = 60,
				ItemTemplate = new DataTemplate(typeof(CustomCell))


			};

			listView.ItemSelected += userDetails;

			Content = new StackLayout
			{
				BackgroundColor = Color.Snow,
				Children = { usernamelabel, label, listView }
			};

		}

		async void userDetails(object seneder, SelectedItemChangedEventArgs e)
		{

			if (e.SelectedItem == null)
			{
				return; //ItemSelected is called on deselection, which results in SelectedItem being set to null
			}

			listView.SelectedItem = null;

			List<DataTable> list = await App.Database.GetItemsAsync();


			// show allert before moveing page and passing data

			await DisplayAlert("Loading", "Moving to view the detail and reply", "Ok");
			await Navigation.PushAsync(new Replypage()
			{
				BindingContext = e.SelectedItem as Items
			});
		}


	}
}


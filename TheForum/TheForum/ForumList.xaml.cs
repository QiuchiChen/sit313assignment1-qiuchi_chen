using System;
using System.Collections.Generic;
using System.Diagnostics;
using Xamarin.Forms;

namespace TheForum
{
    public partial class ForumList : ContentPage
    {
        ListView listView;
       

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


        public async void LoadData(string TitleName)
        {
            //Load the json from datastore
            UserWebRequest request = new UserWebRequest();
            string afterRequest = await request.GetPost(TitleName);
            //Json convert to list
            JsonString jstring = new JsonString();

            if (afterRequest == null){
                
            }else{
				//Add to listview
				listView.ItemsSource = jstring.ConvertToList(afterRequest);

			}


  
        }

        public ForumList(string TitleName)
        {
                LoadData(TitleName);




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

            List<DataTable> list = await App.Database.GetItemsAsync();


            if(list.Count == 0){

                await DisplayAlert("Error", "Reply before login", "Ok");
            }else{
                
				await DisplayAlert("Loading", "Moving to view the detail and reply", "Ok");
				await Navigation.PushAsync(new Replypage()
				{
					BindingContext = e.SelectedItem as Items
				});
            }

		
		}
    }
}

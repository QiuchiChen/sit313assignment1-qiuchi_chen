using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace TheForum
{
    public partial class settings : ContentPage
    {

        Label usernamelabel;

        public settings()
        {

            //GetUser();

			InitializeComponent();


			Title = "User Center";
			BackgroundColor = Color.Black;


			Label TitleLabel = new Label
			{
				Text = "User Center",
				HorizontalOptions = LayoutOptions.Center,
				FontAttributes = FontAttributes.Bold,
				TextColor = Color.NavajoWhite,
				FontSize = 35
			};

		  usernamelabel = new Label
			{
				HorizontalOptions = LayoutOptions.Center,
				FontAttributes = FontAttributes.Bold,
				TextColor = Color.White,
				FontSize = 30
			};


           

            //create the New Post button
            Button NewpostButton = new Button
            {
				Text = "NewPost",
				TextColor = Color.White,
				BackgroundColor = Color.Silver,
				FontSize = 20,
				FontAttributes = FontAttributes.Bold,
				HorizontalOptions = LayoutOptions.FillAndExpand
            };
            NewpostButton.Clicked += Newpost;

			//create mypost button to View a list of all posts per user
			Button MypostButton = new Button
			{
				Text = "My post",
				TextColor = Color.White,
				BackgroundColor = Color.Silver,
				FontSize = 20,
				FontAttributes = FontAttributes.Bold,
				HorizontalOptions = LayoutOptions.FillAndExpand
			};
			MypostButton.Clicked += Mypost;

		//Create logout button
			Button logoutButton = new Button
			{
				Text = "Logout",
				TextColor = Color.White,
                BackgroundColor = Color.Red,
				FontSize = 20,
				FontAttributes = FontAttributes.Bold,
				HorizontalOptions = LayoutOptions.FillAndExpand
			};
			logoutButton.Clicked += loggedout;



			//Fit all different views into the page
			Content = new StackLayout
			{
				Padding = 20,
				Spacing = 60,
                Children = { TitleLabel,usernamelabel,NewpostButton,MypostButton,logoutButton   }
			};


			async void loggedout(object sender, EventArgs e)
			{

                //var data = (DataTable)BindingContext;
                //await App.Database.DeleteItemAsync(data);

               App.Database.DropTable();

                await Navigation.PushModalAsync(new NavigationPage(new TabbedPage()
				{
                    BindingContext = new DataTable() ,
					Children = {
					 new TheForumPage (){ BindingContext = new DataTable() },
                        new LoginPage(){BindingContext = new DataTable() } ,
                   
                    //new settings(),


                }
                }));
			}

			async void Newpost(object sender, EventArgs e)
			{
				await Navigation.PushAsync(new PostCategoryPage());
			}

			async void Mypost(object sender, EventArgs e)
			{
                await Navigation.PushAsync(new UserListPage(usernamelabel.Text) { BindingContext = new DataTable() });
			}
            //CALL GET USER NAME FUNCTION
			GetUser();

		}
        // The function which get the username
		public async void GetUser()
		{
			DataTable data = await App.Database.LoadUser();
			usernamelabel.Text = data.username;
		}
    }
}

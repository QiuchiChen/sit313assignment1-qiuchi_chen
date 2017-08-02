﻿using Xamarin.Forms;

namespace TheForum
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();
           

            MainPage = new NavigationPage(new TabbedPage()
 
            { Children = {
					 new TheForumPage (),
                    new LoginPage() ,
                   
                    new settings(),


                }
            });


        }

        protected override void OnStart()
        {
            // Handle when your app starts
        }

        protected override void OnSleep()
        {
            // Handle when your app sleeps
        }

        protected override void OnResume()
        {
            // Handle when your app resumes
        }
    }
}

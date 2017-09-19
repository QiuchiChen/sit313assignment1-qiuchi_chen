﻿using Xamarin.Forms;

namespace TheForum
{
    public partial class App : Application
    {
        static DataPersistence database;

        public App()
        {
            InitializeComponent();


            MainPage = new NavigationPage(new TabbedPage()

            {
                Children = {
                     new TheForumPage (),
                    new LoginPage(){
                        BindingContext = new DataTable()
                    } ,
                   
                    //new settings(),
                }
            });
        }


		public static DataPersistence Database
		{
			get
			{
				if (database == null)
				{
					database = new DataPersistence(DependencyService.Get<IFileHelper>().GetLocalFilePath("DataStore.db3"));
				}
				return database;
			}
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

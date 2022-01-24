using System;
using System.IO;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Bill_Tracker
{
    public partial class App : Application
    {
        
        private static Database _database;

        internal static Database Database
        {
            get
            {
                if (_database == null)
                {
                    _database = new Database(
                        Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "Records.db3")
                    );
                }

                return _database;
            }
        }

        public App()
        {
            InitializeComponent();


            MainPage = new MainPage(TestCases.TestRecord01(), 0);
        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}

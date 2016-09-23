using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using Xamarin.Forms;

namespace BloodDonors
{
    public class App : Application
    {
        static TodoItemDatabase database;

        public App()
        {
            Resources = new ResourceDictionary();
            Resources.Add("Black", Color.FromHex("000000"));

            var nav = new NavigationPage(new HomePage());
            nav.BarBackgroundColor = (Color)App.Current.Resources["Black"];
            nav.BarTextColor = Color.White;

            MainPage = nav;
        }

        public static TodoItemDatabase Database
        {
            get
            {
                if (database == null)
                {
                    database = new TodoItemDatabase();
                }
                return database;
            }
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

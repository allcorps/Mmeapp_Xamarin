using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;


namespace MMeApp
{
    public partial class App : Application
    {
        //modificar
        public App(String filename)
        {
            InitializeComponent();

            MainPage = new NavigationPage(new MainPage());
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

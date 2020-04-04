using DManager.Views;
using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace DManager
{
    public partial class App : Application
    {
        [Obsolete]
        public App()
        {
            InitializeComponent();

            MainPage = new NavigationPage(new StartPage())
            {
                BarBackgroundColor = Color.FromHex("#4A78D6"),
                BarTextColor = Color.White
            };
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

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace DManager.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class StartPage : ContentPage
    {
        public StartPage()
        {
            InitializeComponent();
        }
        private void StartButton_Clicked(object sender, EventArgs e)
        {
            DebtsViews MainView = new DebtsViews();
            NavigationPage.SetHasBackButton(MainView, false);
            Navigation.PushAsync(MainView);
        }
    }
}
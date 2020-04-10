using DManager.DataSource;
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
    public partial class DebtUserPage : ContentPage
    {

        string UserName;
        public DebtUserPage(Models.PreviewDebtModel DebtInfo)
        {
            InitializeComponent();
            Title = DebtInfo.Name + " = " + DebtInfo.DebtSum.ToString();
            UserName = DebtInfo.Name;
            BindingContext = new ViewModels.ChangeViewModel(DebtInfo.Name);
        }

        private void DeleteDebtButton_Clicked(object sender, EventArgs e)
        {
            DebtData Worker = new DebtData();
            Worker.EraseByName(UserName);
            DisplayAlert("Success", "Your debt has been successfully deleted.", "OK");
            Navigation.PopAsync();
        }
    }
}
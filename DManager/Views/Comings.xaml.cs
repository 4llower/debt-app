using DManager.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace DManager
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Comings : ContentPage
    {
        public Comings()
        {
            InitializeComponent();
            BindingContext = new ViewModels.DebtViewModel(true);
        }

        private void ListView_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            Models.PreviewDebtModel temp = (Models.PreviewDebtModel)e.SelectedItem;
            Navigation.PushAsync(new DebtUserPage(temp));
        }
    }
}
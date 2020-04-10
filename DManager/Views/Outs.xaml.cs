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
    public partial class Outs : ContentPage
    {
        public Outs()
        {
            InitializeComponent();
            Refresh();
        }

        private void ListView_ItemTapped(object sender, ItemTappedEventArgs e)
        {
            Models.PreviewDebtModel temp = (Models.PreviewDebtModel)e.Item;
            Navigation.PushAsync(new DebtUserPage(temp));
        }

        public void Refresh()
        {
            BindingContext = new ViewModels.DebtViewModel(false);
        }
    }
}
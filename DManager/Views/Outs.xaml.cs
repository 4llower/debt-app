using DManager.Models;
using DManager.ViewModels;
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
            refresh();
        }

        private void ListView_ItemTapped(object sender, ItemTappedEventArgs e)
        {
            PreviewDebtModel temp = (PreviewDebtModel)e.Item;
            Navigation.PushAsync(new DebtUserPage(temp));
        }

        public void refresh()
        {
            BindingContext = new DebtViewModel(false);
        }
    }
}
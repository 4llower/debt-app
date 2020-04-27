using DManager.DataSource;
using DManager.Models;
using DManager.ViewModels;
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
        private DebtModel CurrentSelectItem;
        private string UserName;
        private double CurrentDebt;
        public DebtUserPage(PreviewDebtModel DebtInfo)
        {
            InitializeComponent();
            UserName = DebtInfo.Name;
            CurrentDebt = DebtInfo.DebtSum;
            CurrentSelectItem = new DebtModel();
            Refresh();

            // Add debt button ********
            ToolbarItem AddDebtButton = new ToolbarItem
            {
                Text = "Add Debt",
                Order = ToolbarItemOrder.Primary,
                Priority = 0,
                Icon = new FileImageSource
                {
                    File = "iconAdd.png"
                }
            };

            AddDebtButton.Clicked += (s, e) =>
            {
                Navigation.PopAsync();
                Navigation.PushAsync(new CreateDebtPage("Comings", DebtInfo.Name));
            };

            ToolbarItems.Add(AddDebtButton);
            //********
        }

        private void DeleteDebtButton_Clicked(object sender, EventArgs e)
        {
            DebtController.eraseByName(UserName);
            
            DisplayAlert("Success", "Your debt has been successfully deleted.", "OK");

            ((DebtsViews)Navigation.NavigationStack.ToList<Page>()[0]).refresh();

            Navigation.PopAsync();
        }

        private bool IsEmpty(DebtModel Value)
        {
            return String.IsNullOrEmpty(Value.Name);
        }

        void Refresh()
        {
            BindingContext = new ChangeViewModel(UserName);
            Title = UserName + " = " + CurrentDebt.ToString();
        }

        private void DeleteSelectButton_Clicked(object sender, EventArgs e)
        {
            if (IsEmpty(CurrentSelectItem))
            {
                DisplayAlert("Error", "You are not select the debt.", "OK");
                return;
            }

            DebtController.eraseByFields(CurrentSelectItem);
            CurrentSelectItem.Name = "";

            CurrentDebt -= CurrentSelectItem.DebtChange;
            Refresh();

            ((DebtsViews)Navigation.NavigationStack.ToList<Page>()[0]).refresh();

            if (DebtController.getNumberChanges(CurrentSelectItem.Name) == 0) Navigation.PopAsync();
        }

        private void ListView_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            CurrentSelectItem = (DebtModel)e.SelectedItem;
        }
    }
}
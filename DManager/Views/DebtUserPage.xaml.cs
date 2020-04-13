using DManager.DataSource;
using DManager.Models;
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
        private DebtData Worker;
        public DebtUserPage(Models.PreviewDebtModel DebtInfo)
        {
            InitializeComponent();
            UserName = DebtInfo.Name;
            CurrentDebt = DebtInfo.DebtSum;
            Worker = new DebtData();
            CurrentSelectItem = new DebtModel();
            Refresh();
            
            /*
                REFRESH TOOL

            ToolbarItem RefreshButton = new ToolbarItem
            {
                Text = "Refresh",
                Order = ToolbarItemOrder.Primary,
                Priority = 0,
                Icon = new FileImageSource
                {
                    File = "iconRefresh.png"
                }
            };

            RefreshButton.Clicked += async (s, e) =>
            {
                Refresh();
            };

            ToolbarItems.Add(RefreshButton);

            */
        }

        private void DeleteDebtButton_Clicked(object sender, EventArgs e)
        {
            DebtData Worker = new DebtData();
            Worker.EraseByName(UserName);
            DisplayAlert("Success", "Your debt has been successfully deleted.", "OK");
            Navigation.PopAsync();
        }

        private bool IsEmpty(DebtModel Value)
        {
            return String.IsNullOrEmpty(Value.Name);
        }

        void Refresh()
        {
            BindingContext = new ViewModels.ChangeViewModel(UserName);
            Title = UserName + " = " + CurrentDebt.ToString();
        }

        private void DeleteSelectButton_Clicked(object sender, EventArgs e)
        {
            if (IsEmpty(CurrentSelectItem))
            {
                DisplayAlert("Error", "You are not select the debt.", "OK");
                return;
            }

            Worker.EraseByFields(CurrentSelectItem);
            CurrentSelectItem.Name = "";
            CurrentDebt -= CurrentSelectItem.DebtChange;
            Refresh();
        }

        private void ListView_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            CurrentSelectItem = (DebtModel)e.SelectedItem;
        }
    }
}
using DManager.Data;
using DManager.Models;
using DManager.ViewModels;
using System;
using System.Linq;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace DManager.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class DebtUserPage : ContentPage
    {
        private string personalityName;
        public DebtUserPage(PreviewDebtModel DebtInfo)
        {
            InitializeComponent();
            personalityName = DebtInfo.Name;
            Refresh();

            /* Close all debts */
            ToolbarItem closeDebtsItem = new ToolbarItem
            {
                Text = "Close all debts",
                Order = ToolbarItemOrder.Secondary,
                Priority = 0
            };

            closeDebtsItem.Clicked += async (s, e) =>
            {
                bool result = await DisplayAlert("Warning", "Are you sure you want to close all debts?", "Yes", "No");

                if (result == true)
                {
                    DBContext.eraseByName(personalityName);
                    ((DebtsViews)Navigation.NavigationStack.ToList<Page>()[0]).refresh();
                    await Navigation.PopAsync();
                }
            };

            /* Sorting by date */
            ToolbarItem sortByDateItem = new ToolbarItem
            {
                Text = "Sort by date",
                Order = ToolbarItemOrder.Secondary,
                Priority = 1
            };

            sortByDateItem.Clicked += (s, e) =>
            {
                BindingContext = new ChangeViewModel(personalityName, TypeSort.ByDate);
            };

            /* Sorting by value */
            ToolbarItem sortByValueItem = new ToolbarItem
            {
                Text = "Sort by debt value",
                Order = ToolbarItemOrder.Secondary,
                Priority = 2
            };

            sortByValueItem.Clicked += (s, e) =>
            {
                BindingContext = new ChangeViewModel(personalityName, TypeSort.ByValue);
            };

            /* Add buttons on nav bar */
            ToolbarItems.Add(closeDebtsItem);
            ToolbarItems.Add(sortByDateItem);
            ToolbarItems.Add(sortByValueItem);
        }

        public void Refresh()
        {
            var _context = new ChangeViewModel(personalityName, TypeSort.Default);

            if (_context.ChangeList.Count == 0)
            {
                ((DebtsViews)Navigation.NavigationStack.ToList<Page>()[0]).refresh();
                Navigation.PopAsync();
                return;
            }

            BindingContext = _context;
            Title = personalityName + ": " + DBContext.getSummaryDebtByName(personalityName).ToString();
        }

        private void AddButton_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new CreateDebtPage("Comings", new DebtModel() { Name = personalityName, DebtChange = 0, Description = "", Date = "" }));
        }

        private async void PersonalDebts_ItemTapped(object sender, ItemTappedEventArgs e)
        {
            string result = await DisplayActionSheet("What to do...", "Cancel", null, "Close this debt", "Change this debt");
            var debtInfo = (DebtModel)e.Item;

            if (result == "Close this debt")
            {
                bool decision = await DisplayAlert("Warning", String.Format("Are you sure you want close this debt({0}, {1}, {2})", debtInfo.DebtChange.ToString(), debtInfo.Description, debtInfo.Date), "YES", "NO");

                if (decision == true)
                {
                    DBContext.eraseByFields(debtInfo);
                    Refresh();
                }
            }

            if (result == "Change this debt")
            {
                await Navigation.PushAsync(new CreateDebtPage("Comings", debtInfo));
            }
        }
    }
}
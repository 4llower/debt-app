using DManager.Data;
using DManager.Models;
using System;
using System.Globalization;
using System.Linq;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;


namespace DManager.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class CreateDebtPage : ContentPage
    {
        private readonly DebtModel debtInfo;
        public CreateDebtPage(string currentPage, DebtModel debtInfo)
        {
            InitializeComponent();
            styleSwitch.IsToggled = (currentPage == "Comings") ? false : true;
            DateDebtStart.Date = DateTime.Now;
            this.debtInfo = debtInfo;

            if (string.IsNullOrEmpty(debtInfo.Name) == false)
            {
                NameField.IsReadOnly = true;
                NameField.Text = debtInfo.Name;
                if (string.IsNullOrEmpty(debtInfo.Date) == false)
                {
                    CultureInfo provider = CultureInfo.InvariantCulture;
                    DateDebtStart.Date = DateTime.ParseExact(debtInfo.Date, "dd/MM/yyyy", provider);
                    ValueField.Text = debtInfo.DebtChange.ToString();
                    DescriptionField.Text = debtInfo.Description;
                }
            }
        }

        private void DebtButton_Clicked(object sender, EventArgs e)
        {

            if (string.IsNullOrEmpty(NameField.Text))
            {
                DisplayAlert("Error", "Name is empty, please verify all information.", "OK");
                return;
            }

            if (string.IsNullOrEmpty(ValueField.Text))
            {
                DisplayAlert("Error", "Sum is empty, please verify all information.", "OK");
                return;
            }

            if (double.TryParse(ValueField.Text, out double value) == false)
            {
                DisplayAlert("Error", "Please enter the correct number", "OK");
                return;
            }

            if (styleSwitch.IsToggled)
            {
                value = -value;
            }

            DebtModel Item = new DebtModel()
            {
                Name = char.ToUpper(NameField.Text[0]) + NameField.Text.Substring(1),
                DebtChange = value,
                Description = !string.IsNullOrEmpty(DescriptionField.Text) ? char.ToUpper(DescriptionField.Text[0]) + DescriptionField.Text.Substring(1) : "",
                Date = DateDebtStart.Date.ToString("dd/MM/yyyy")
            };

            if (string.IsNullOrEmpty(debtInfo.Date) == false)
            {
                DBContext.eraseByFields(debtInfo);
            }

            DBContext.createChange(Item);

            if (string.IsNullOrEmpty(debtInfo.Name) == false)
            {
                ((PersonalityDebtPage)Navigation.NavigationStack.ToList<Page>()[1]).Refresh();
            }

            DisplayAlert("Success", "Your debt has been successfully created.", "OK");
            ((DebtsViews)Navigation.NavigationStack.ToList<Page>()[0]).refresh();
            Navigation.PopAsync();
        }
    }
}
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
    public partial class CreateDebtPage : ContentPage
    {
        public CreateDebtPage(string currentPage, string Name)
        {
            InitializeComponent();
            NameField.Text = Name;
            styleSwitch.IsToggled = (currentPage == "Comings") ? false : true;
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

            if (styleSwitch.IsToggled) value = -value;

            var Item = new DebtModel()
            {
                Name = Char.ToUpper(NameField.Text[0]) + NameField.Text.Substring(1),
                DebtChange = value,
                Description = !string.IsNullOrEmpty(DescriptionField.Text) ? Char.ToUpper(DescriptionField.Text[0]) + DescriptionField.Text.Substring(1) : ""
            };

            DebtController.createChange(Item);

            DisplayAlert("Success", "Your debt has been successfully created.", "OK");
            ((DebtsViews)Navigation.NavigationStack.ToList<Page>()[0]).Refresh();
            Navigation.PopAsync();
        }
    }
}
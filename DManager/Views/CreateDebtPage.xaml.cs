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
        public CreateDebtPage(string currentPage)
        {
            InitializeComponent();
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

            DataSource.DebtData Worker = new DataSource.DebtData();
            double value;

            try
            {
                value = double.Parse(ValueField.Text);
            } 
            catch (Exception)
            {
                DisplayAlert("Error", "Please enter the correct number", "OK");
                return;
            }

            if (styleSwitch.IsToggled) value = -value;

            Models.DebtModel Item = new Models.DebtModel()
            {
                Name = Char.ToUpper(NameField.Text[0]) + NameField.Text.Substring(1),
                DebtChange = value,
                Description = !string.IsNullOrEmpty(DescriptionField.Text) ? Char.ToUpper(DescriptionField.Text[0]) + DescriptionField.Text.Substring(1) : ""
            };

            Worker.MakeChange(Item);

            DisplayAlert("Success", "Your debt has been successfully created.", "OK");
            ((DebtsViews)Navigation.NavigationStack.ToList<Page>()[0]).Refresh();
            Navigation.PopAsync();
        }
    }
}
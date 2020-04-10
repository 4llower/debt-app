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
        public CreateDebtPage()
        {
            InitializeComponent();
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

            double value = double.Parse(ValueField.Text);

            if (styleSwitch.IsToggled) value = -value;

            Models.DebtModel Item = new Models.DebtModel()
            {
                Name = NameField.Text,
                DebtChange = value,
                Description = !string.IsNullOrEmpty(DescriptionField.Text) ? DescriptionField.Text : ""
            };

            Worker.MakeChange(Item);

            DisplayAlert("Success", "Your debt has been successfully created.", "OK");

            Navigation.PopAsync();
        }
    }
}
using DManager.Models;
using DManager.ViewModels;
using DManager.Views;

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
            Navigation.PushAsync(new PersonalityDebtPage(temp));
        }

        public void refresh()
        {
            BindingContext = new CommonDebtView(TypeDebtView.Out);
        }

        private void AddButton_Clicked(object sender, System.EventArgs e)
        {
            Navigation.PushAsync(new CreateDebtPage("Outs", new DebtModel() { Date = "", Name = "", Description = "", DebtChange = 0 }));
        }
    }
}
using DManager.Models;
using DManager.Views;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace DManager
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Comings : ContentPage
    {
        public Comings()
        {
            InitializeComponent();
            refresh();
        }

        public void refresh()
        {
            BindingContext = new ViewModels.CommonDebtView(TypeDebtView.Coming);
        }

        private void ListView_ItemTapped(object sender, ItemTappedEventArgs e)
        {
            PreviewDebtModel temp = (PreviewDebtModel)e.Item;
            Navigation.PushAsync(new PersonalityDebtPage(temp));
        }

        private void AddButton_Clicked(object sender, System.EventArgs e)
        {
            Navigation.PushAsync(new CreateDebtPage("Comings", new DebtModel() { Date = "", Name = "", Description = "", DebtChange = 0 }));
        }
    }
}
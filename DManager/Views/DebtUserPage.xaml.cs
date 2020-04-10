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
        public DebtUserPage(Models.PreviewDebtModel DebtInfo)
        {
            InitializeComponent();
            Title = DebtInfo.Name + " = " + DebtInfo.DebtSum.ToString();
            BindingContext = new ViewModels.ChangeViewModel(DebtInfo.Name);
        }
    }
}
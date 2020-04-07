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
        public DebtUserPage(Models.PreviewDebtModel s)
        {
            InitializeComponent();
            TextLabel.Text = s.Name;
        }
    }
}
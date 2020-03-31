using DManager.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace DManager
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class DebtsViews : TabbedPage
    {
        [Obsolete]
        public DebtsViews()
        {
            InitializeComponent();

            BarBackgroundColor = Color.FromHex("#4A78D6");
            BarTextColor = Color.White;

            ToolbarItem CreateDebt = new ToolbarItem
            {
                Text = "help",
                Order = ToolbarItemOrder.Primary,
                Priority = 0,
                Icon = new FileImageSource
                {
                    File = "iconAdd.png"
                }
            };

            CreateDebt.Clicked += async (s, e) =>
            {
                await Navigation.PushAsync(new CreateDebtPage());
            };

            ToolbarItems.Add(CreateDebt);

        }
    }
}
using DManager.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using SQLite;
using System.IO;

namespace DManager
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class DebtsViews : TabbedPage
    {
        private string currentPageName;

        [Obsolete]
        public DebtsViews()
        {
            InitializeComponent();
           
            BarBackgroundColor = Color.FromHex("#4A78D6");
            BarTextColor = Color.White;

            // ADD SUB PAGES
            Children.Add(new Comings());
            Children.Add(new Outs());
            // ADD SUB PAGES

            //CREATE DEBT TOOL ********

            ToolbarItem CreateDebt = new ToolbarItem
            {
                Text = "Debt",
                Order = ToolbarItemOrder.Primary,
                Priority = 0,
                Icon = new FileImageSource
                {
                    File = "iconAdd.png"
                }
            };

            CreateDebt.Clicked += async (s, e) =>
            {
                await Navigation.PushAsync(new CreateDebtPage(currentPageName, ""));
            };

            ToolbarItems.Add(CreateDebt);

            /*
                   REFRESH TOOL 

            ToolbarItem RefreshButton = new ToolbarItem
            {
                Text = "Refresh",
                Order = ToolbarItemOrder.Primary,
                Priority = 0,
                Icon = new FileImageSource
                {
                    File = "iconRefresh.png"
                }
            };

            RefreshButton.Clicked += async (s, e) =>
            {
                Refresh();
            };

            ToolbarItems.Add(RefreshButton); 
            
            */
        }

        protected override void OnCurrentPageChanged()
        {
            currentPageName = CurrentPage.Title;
        }

        public void Refresh()
        {
            ((Comings)Children.ElementAt(0)).Refresh();
            ((Outs)Children.ElementAt(1)).Refresh();
        }
    }
}
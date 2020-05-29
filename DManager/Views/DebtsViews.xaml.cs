using System;
using System.Linq;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

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

            /* Childred pages to tab page */
            Children.Add(new Comings());
            Children.Add(new Outs());
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
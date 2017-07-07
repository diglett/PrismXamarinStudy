using Prism.Navigation;
using Xamarin.Forms;
using System;

namespace PrismXamarinStudy.Views
{
    public partial class NavigationPageView : NavigationPage, INavigationPageOptions
    {
        public NavigationPageView()
        {
            InitializeComponent();
        }

        public bool ClearNavigationStackOnNavigation
        {
            get { return true; }
        }
    }
}

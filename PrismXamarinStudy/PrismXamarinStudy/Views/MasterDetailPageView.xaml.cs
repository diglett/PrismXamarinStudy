using System;
using Prism.Commands;
using Prism.Navigation;
using Xamarin.Forms;

namespace PrismXamarinStudy.Views
{
    public partial class MasterDetailPageView : MasterDetailPage, IMasterDetailPageOptions
    {
        public MasterDetailPageView()
        {
            InitializeComponent();
        }

        public bool IsPresentedAfterNavigation
        {
            get { return Device.Idiom != TargetIdiom.Phone; }
        }
    }
}
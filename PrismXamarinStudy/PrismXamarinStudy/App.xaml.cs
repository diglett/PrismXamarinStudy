using Modules;
using Prism.Modularity;
using Prism.Navigation;
using Prism.Unity;
using PrismXamarinStudy.Views;
using System;

namespace PrismXamarinStudy
{
    public partial class App : PrismApplication
    {
        public App(IPlatformInitializer initializer = null) : base(initializer) { }

        protected override void OnInitialized()
        {
            InitializeComponent();

            var parameters = new NavigationParameters();
            parameters.Add("title", "Hello from Xamarin.Forms");

            NavigationService.NavigateAsync("MasterDetailPageView/NavigationPageView/MainPageView", parameters);
        }

        protected override void RegisterTypes()
        {
            Container.RegisterTypeForNavigation<MasterDetailPageView>();
            Container.RegisterTypeForNavigation<NavigationPageView>();
            Container.RegisterTypeForNavigation<MainPageView>();
            Container.RegisterTypeForNavigation<SecondPageView>();
        }

        protected override void ConfigureModuleCatalog()
        {
            ModuleCatalog.AddModule(new ModuleInfo(typeof(ModuleA)));
        }
    }
}

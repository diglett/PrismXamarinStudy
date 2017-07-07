using Prism.Commands;
using Prism.Modularity;
using Prism.Mvvm;
using Prism.Navigation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Input;

namespace PrismXamarinStudy.ViewModels
{
    public class MainPageViewModel : ExtendedBindableBase, INavigationAware
    {
        private readonly IModuleManager _moduleManager;
                
        public string Title
        {
            get { return Get(() => Title); }
            set { Set(() => Title, value); }
        }

        public ICommand SecondPageCommand
        {
            get
            {
                return new DelegateCommand(() =>
                   {
                       NavigateAsync("SecondPageView");
                   });
            }
        }

        public MainPageViewModel(INavigationService navigationService, IModuleManager moduleManager) : base(navigationService)
        {
            _moduleManager = moduleManager;
            //LoadModuleACommand = new DelegateCommand(LoadModuleA);
        }

        public void OnNavigatedFrom(NavigationParameters parameters)
        {

        }

        public void OnNavigatedTo(NavigationParameters parameters)
        {
            if (parameters.ContainsKey("title"))
                Title = (string)parameters["title"] + " and Prism";
        }

        public void OnNavigatingTo(NavigationParameters parameters)
        {

        }
    }
}

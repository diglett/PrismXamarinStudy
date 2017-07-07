using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;
using System;
using System.Collections.Generic;
using System.Linq;

namespace PrismXamarinStudy.ViewModels
{
    public class MasterDetailPageViewModel : ExtendedBindableBase
    {
        public DelegateCommand<string> NavigateCommand { get; set; }

        public MasterDetailPageViewModel(INavigationService navigationService) : base(navigationService)
        {
            NavigateCommand = new DelegateCommand<string>(Navigate);
        }

        private void Navigate(string name)
        {
            NavigateAsync(name);
        }
    }
}

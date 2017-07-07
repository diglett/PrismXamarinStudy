using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Input;

namespace PrismXamarinStudy.ViewModels
{
    public class SecondPageViewModel : ExtendedBindableBase
    {
        public ICommand GoBackCommand
        {
            get
            {
                return new DelegateCommand(() =>
                {
                    GoBackAsync();
                });
            }
        }

        public SecondPageViewModel(INavigationService navigationService) : base(navigationService)
        {
        }
    }
}

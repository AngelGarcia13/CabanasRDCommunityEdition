using System;
using CabanasRD.UI.ViewModels;
using Prism.Navigation;

namespace CabanasRD.UI.Main.ViewModels
{
    public class MainTabbedPageViewModel : ViewModelBase
    {
        public MainTabbedPageViewModel(INavigationService navigationService)
            : base(navigationService)
        {

        }
    }
}

using BankingSystem.Utilities.Stores;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankingSystem.ViewModel
{
    public class MainWindowVM : ViewModelBase
    {
		public ViewModelBase CurrentVM => _navigationStore.CurrentVM;
        public ViewModelBase NavSideBarVM => _navigationStore.NavSideBarVM;
        private NavigationStore _navigationStore;

        public MainWindowVM(NavigationStore navigationStore)
        {
            _navigationStore = navigationStore;
            _navigationStore.CurrentVMChanged += _navigationStore_CurrentVMChanged;
            _navigationStore.NavSideBarVMChanged += _navigationStore_NavSideBarVMChanged; ;
        }

        private void _navigationStore_NavSideBarVMChanged()
        {
            OnPropertyChanged(nameof(NavSideBarVM));
        }

        private void _navigationStore_CurrentVMChanged()
        {
            OnPropertyChanged(nameof(CurrentVM));
        }
    }
}

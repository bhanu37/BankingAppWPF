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
        private NavigationStore _navigationStore;

        public MainWindowVM(NavigationStore navigationStore)
        {
            _navigationStore = navigationStore;
            _navigationStore.CurrentVMChanged += _navigationStore_CurrentVMChanged;
        }

        private void _navigationStore_CurrentVMChanged()
        {
            OnPropertyChanged(nameof(CurrentVM));
        }
    }
}

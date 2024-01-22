using BankingSystem.Utilities.Stores;

namespace BankingSystem.ViewModel
{
    public class MainWindowVM : ViewModelBase
    {
		public ViewModelBase CurrentVM => _navigationStore.CurrentVM;
        public ViewModelBase NavSideBarVM => _navigationStore.NavSideBarVM;
        public ViewModelBase TopBarVM => _navigationStore.TopBarVM;
        private NavigationStore _navigationStore;

        public MainWindowVM(NavigationStore navigationStore)
        {
            _navigationStore = navigationStore;
            _navigationStore.CurrentVMChanged += _navigationStore_CurrentVMChanged;
            _navigationStore.NavSideBarVMChanged += _navigationStore_NavSideBarVMChanged;
            _navigationStore.TopBarVMChanged += _navigationStore_TopBarVMChanged;
        }


        private void _navigationStore_NavSideBarVMChanged()
        {
            OnPropertyChanged(nameof(NavSideBarVM));
        }

        private void _navigationStore_CurrentVMChanged()
        {
            OnPropertyChanged(nameof(CurrentVM));
        }
        private void _navigationStore_TopBarVMChanged()
        {
            OnPropertyChanged(nameof(TopBarVM));
        }
    }
}

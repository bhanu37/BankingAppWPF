using BankingSystem.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankingSystem.Utilities.Stores
{
    public class NavigationStore
    {
		private ViewModelBase _currentVM;
		private ViewModelBase _navSideBarVM;
        private ViewModelBase _topBarVM;
        private string _currVMTitle;
		public event Action CurrentVMChanged;
		public event Action CurrVMTitleChanged;
		public event Action NavSideBarVMChanged;
		public event Action TopBarVMChanged;

        public string CurrVMTitle
        {
            get { return _currVMTitle; }
            set 
            { 
                _currVMTitle = value;
                OnCurrentVMTitleChanged();
            }
        }

        public ViewModelBase CurrentVM
		{
			get { return _currentVM; }
			set 
			{
				_currentVM = value;
				OnCurrentVMChanged();
			}
		}

        public ViewModelBase NavSideBarVM
        {
            get { return _navSideBarVM; }
            set
            {
                _navSideBarVM = value;
                OnNavSideBarVMChanged();
            }
        }

        public ViewModelBase TopBarVM
        {
            get { return _topBarVM; }
            set
            {
                _topBarVM = value;
                OnTopBarVMChanged();
            }
        }

        private void OnCurrentVMTitleChanged()
        {
            CurrVMTitleChanged?.Invoke();
        }
        private void OnNavSideBarVMChanged()
        {
            NavSideBarVMChanged?.Invoke();
        }

        private void OnCurrentVMChanged()
		{
			CurrentVMChanged?.Invoke();
		}
        private void OnTopBarVMChanged()
        {
            TopBarVMChanged?.Invoke();
        }
    }
}

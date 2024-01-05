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
		public event Action CurrentVMChanged;
		public event Action NavSideBarVMChanged;

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

        private void OnNavSideBarVMChanged()
        {
            NavSideBarVMChanged?.Invoke();
        }

        private void OnCurrentVMChanged()
		{
			CurrentVMChanged?.Invoke();
		}
    }
}

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
		public event Action CurrentVMChanged;

		public ViewModelBase CurrentVM
		{
			get { return _currentVM; }
			set 
			{
				_currentVM = value;
				OnCurrentVMChanged();
			}
		}

		private void OnCurrentVMChanged()
		{
			CurrentVMChanged?.Invoke();
		}
    }
}

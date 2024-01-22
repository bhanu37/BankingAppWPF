using BankingSystem.Utilities.Stores;
using BankingSystem.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankingSystem.Utilities.Commands
{
    public class NavigationCommand : CommandBase
    {
        private NavigationStore _navigationStore;
        private Func<ViewModelBase> _currentVM;

        public NavigationCommand(NavigationStore navigationStore, Func<ViewModelBase> currentVM)
        {
            _navigationStore = navigationStore;
            _currentVM = currentVM;
        }

        public override void Execute(object? parameter)
        {
            _navigationStore.CurrentVM = _currentVM();
            _navigationStore.CurrVMTitle = parameter?.ToString();
        }
    }
}

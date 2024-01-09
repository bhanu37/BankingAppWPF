using BankingSystem.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace BankingSystem.Utilities.Services.DialogsService
{
    public interface IDialogService
    {
        public void ShowDialog<TView, TViewModel>(TView vw, TViewModel vm)
            where TView : UserControl
            where TViewModel : ViewModelBase;
    }
}

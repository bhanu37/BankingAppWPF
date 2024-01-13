using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace BankingSystem.View.PopupsAndDialogs
{
    /// <summary>
    /// Interaction logic for CreateUpdateBankAccountDialogView.xaml
    /// </summary>
    public partial class CreateUpdateBankAccountDialogView : UserControl
    {
        public CreateUpdateBankAccountDialogView()
        {
            InitializeComponent();
        }
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            var window = this.Parent as Window;
            window.Close();
        }
    }
}

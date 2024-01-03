using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankingSystem.Utilities.Commands
{
    public class FunctionalCommand : CommandBase
    {
        public Action UserLogin { get; }

        public FunctionalCommand(Action userLogin)
        {
            UserLogin = userLogin;
        }

        public override void Execute(object? parameter)
        {
            UserLogin();            
        }
    }
}

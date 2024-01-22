using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankingSystem.Utilities.Commands
{
    public class FunctionalCommand : CommandBase
    {
        public Action ExecuteAction { get; }

        public FunctionalCommand(Action executeAction)
        {
            ExecuteAction = executeAction;
        }

        public override void Execute(object? parameter)
        {
            ExecuteAction();            
        }
    }
}

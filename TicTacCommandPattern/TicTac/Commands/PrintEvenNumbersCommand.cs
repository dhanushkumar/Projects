
using System.Collections.Generic;
using System.Linq;
using System.Text;


namespace TicTac.Calculator
{
    
    public class PrintEvenNumbersCommand: CommandBase
    {
        public PrintEvenNumbersCommand(IReceiver receiver) : base(receiver)
        {
        }
       
        /// <summary>
        /// Executes the command
        /// </summary>
        public override void Execute()
        {
               
                   if (currentIteration % 2 == 0)
                    {
                        receiver.Process(new Result { Value = currentIteration });
                    }
           
        }

    }
}

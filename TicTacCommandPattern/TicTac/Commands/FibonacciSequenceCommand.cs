
using System.Collections.Generic;
using System.Linq;
using System.Text;


namespace TicTac.Calculator
{
    
    public class FibonacciSequenceCommand : CommandBase
    {
        public FibonacciSequenceCommand(IReceiver receiver) : base(receiver)
        {
        }

        private int a;
        private int b;
        private int temp;

        /// <summary>
        /// Executes the command
        /// </summary>
        public override void Execute()
        {
                if (this.inputNumbers.Count >= 2)
                {
                    if(temp <= 0)
                    {
                        a = this.inputNumbers[this.inputNumbers.Count - 2].Value;
                        b = this.inputNumbers.Last().Value;
                    }
                    else
                    {
                        a = b;
                        b = temp;
                    }
                    temp = a + b;
                    receiver.Process(new Result { Value = temp });
                }
            
        }

    }
}

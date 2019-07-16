
using System.Collections.Generic;
using System.Linq;
using System.Text;


namespace TicTac.Calculator
{
    
    public class DivisibilityCheckCommand: CommandBase
    {
        public DivisibilityCheckCommand(IReceiver receiver) : base(receiver)
        {
        }
       
        /// <summary>
        /// Executes the command
        /// </summary>
        public override void Execute()
        {
                var name = new StringBuilder();
                foreach (var input in this.inputNumbers)
                {
                   if (currentIteration % input.Value == 0)
                    {
                        if (!inputNumbers.LastOrDefault().Equals(input))
                         {
                            name.AppendFormat("{0} ", input.Alias);
                         }
                        else
                        {
                            name.Append(input.Alias);
                        }
                    }
                }
            receiver.Process(new Result { Value = currentIteration, Alias = name.ToString().ToUpperInvariant() });
        }

    }
}

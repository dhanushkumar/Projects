
using System.Collections.Generic;
using System.Linq;
using System.Text;


namespace TicTac.Calculator
{
    
    public class DivisibilityCheckCommand : ICommand
    {
        private readonly List<INumber> rightDivisibilityNumbers = new List<INumber>();
        private readonly IReceiver receiver;
        private int leftDivisionNumber;

        /// <summary>
        /// This class determines if a given number is divisible against a list of numbers provided.
        /// Prints out the Aliases of all the divisible numbers
        /// </summary>
        /// <param name="receiver">Used to print out result to the console</param>
        public DivisibilityCheckCommand(IReceiver receiver)
        {
            this.receiver = receiver;
        }

            /// <summary>
            /// Accept number to check divisibility against. 
            /// </summary>
            /// <param name="rightDivisibleNumber">right divisible number and its Alias</param>
            public void Accept(INumber rightDivisibleNumber)
        {
            this.rightDivisibilityNumbers.Add(rightDivisibleNumber);
        }
        
        /// <summary>
        /// Executes the command
        /// </summary>
        public void Execute()
        {
                var name = new StringBuilder();
                foreach (var number in rightDivisibilityNumbers)
                {
                   if (leftDivisionNumber % number.Value == 0)
                    {
                        if (!rightDivisibilityNumbers.LastOrDefault().Equals(number))
                         {
                            name.AppendFormat("{0} ", number.Alias);
                         }
                        else
                        {
                            name.Append(number.Alias);
                        }
                    }
                }
            receiver.WriteToConsole(new Result { Value = leftDivisionNumber, Alias = name.ToString().ToUpperInvariant() });
        }

      
        /// <summary>
        /// sets the left divisible number
        /// </summary>
        /// <param name="leftDivisionNumber"></param>
        public void Set(int leftDivisionNumber)
        {
            this.leftDivisionNumber = leftDivisionNumber;
        }
    }
}

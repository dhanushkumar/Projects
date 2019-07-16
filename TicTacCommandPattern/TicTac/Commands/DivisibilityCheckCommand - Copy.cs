
/*using System.Collections.Generic;

using System.Text;


namespace TicTac.Calculator
{
    
    public class DivisibilityCheckCommand : ICommand
    {
        private readonly List<INumber> rightDivisibilityNumbers = new List<INumber>();
        private readonly IReceiver receiver;
        internal int leftDivisionNumber;

        public int Iterations { get; private set; }
        public int CurrentIteration { get => leftDivisionNumber; set => leftDivisionNumber = value; }




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
            receiver.Process(new Result { Value = leftDivisionNumber, Alias = name.ToString().ToUpperInvariant() });
        }

        /// <summary>
        /// sets the number iterations to be performed for the command
        /// </summary>
        /// <param name="iterations"></param>
        public void Set(int iterations)
        {
            this.Iterations = iterations;
        }
    }
}
*/
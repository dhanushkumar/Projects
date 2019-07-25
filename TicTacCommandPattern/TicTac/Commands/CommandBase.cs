
using System.Collections.Generic;

namespace TicTac.Calculator
{
    
    public abstract class CommandBase : ICommand
    {
        protected readonly List<INumber> inputNumbers = new List<INumber>();
        protected readonly IReceiver receiver;
        internal int currentIteration;

        /// <summary>
        /// Sets the number of iterations the command should be executed
        /// </summary>
        public int Iterations { get; private set; }

        /// <summary>
        /// Determines the current iteration the command is being executed
        /// </summary>
        public int CurrentIteration { private get => currentIteration; set => currentIteration = value; }


        ///// <summary>
        ///// This class determines if a given number is divisible against a list of numbers provided.
        ///// Prints out the Aliases of all the divisible numbers
        ///// </summary>
        ///// <param name="receiver">Used to print out result to the console</param>
        public CommandBase(IReceiver receiver)
        {
            this.receiver = receiver;
        }

        /// <summary>
        /// Accept number to check divisibility against. 
        /// </summary>
        /// <param name="inputNumber">right divisible number and its Alias</param>
        public void Accept(INumber inputNumber)
        {
            this.inputNumbers.Add(inputNumber);
        }

        /// <summary>
        /// Executes the command
        /// </summary>
        public abstract void Execute();

        /// <summary>
        /// sets the number iterations to be performed for the command
        /// </summary>
        /// <param name="iterations"></param>
        public void SetIterations(int iterations)
        {
            this.Iterations = iterations;
        }

    }
}

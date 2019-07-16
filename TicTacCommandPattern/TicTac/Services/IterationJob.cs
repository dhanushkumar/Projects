using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicTac.Calculator
{
    public class IterationJob : IIterationJob
    {

        private readonly List<ICommand> commands = new List<ICommand>();
        private int iterations;

        public int Iterations => throw new NotImplementedException();

       //public int CurrentIteration => throw new NotImplementedException();

        public int CurrentIteration { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        public void Set(int iterations)
        {
            this.iterations = iterations;
        }

        public void Add(ICommand command)
        {
            commands.Add(command);
        }
    }
}

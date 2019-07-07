using System.Collections.Generic;
namespace TicTac.Calculator

{
    public class CalculatorService : ICalculatorService
    {
        private readonly List<ICommand> commands = new List<ICommand>();
        private  int iterations;
        public void Start()
        {
           foreach(var command in commands)
            {
                for (int i = 0; i < iterations; i++)
                {
                    command.Set(i);
                    command.Execute();
                }
            }
        }

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

using System.Collections.Generic;
using System.Linq;
namespace TicTac.Calculator

{
    public class CalculatorService : ICalculatorService
    {
        private readonly List<ICommand> commands = new List<ICommand>();

        public void Run()
        {
           foreach(var command in commands)
            {
                for (int i = 0; i < command.Iterations; i++)
                {
                    command.CurrentIteration = i;
                    command.Execute();
                }
            }
        }

        public void AddCommand(ICommand command)
        {
            commands.Add(command);
        }

        public ICommand GetCommand<T>()
        {
            return commands.OfType<T>().SingleOrDefault() as ICommand;
        }
    }
}

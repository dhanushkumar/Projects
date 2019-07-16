using System.Collections.Generic;
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

        public void Add(ICommand command)
        {
            commands.Add(command);
        }
    }
}

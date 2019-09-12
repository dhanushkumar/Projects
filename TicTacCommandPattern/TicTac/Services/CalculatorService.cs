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

        /// <summary>
        /// Add the command to the list
        /// </summary>
        /// <param name="command"></param>
        public void AddCommand(ICommand command)
        {
            commands.Add(command);
        }

        /// <summary>
        /// Returns the command implemntation for the specifc type 
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <returns>ICommand</returns>
        public ICommand GetCommand<T>()
        {
           
            if (!typeof(ICommand).IsAssignableFrom(typeof(T)))
            {
                throw new System.NotImplementedException(string.Format("Type '{0}' does not implement ICommand. Type must be an implementation of the interface ICommand", typeof(T).Name));
            }
            return commands.OfType<T>().SingleOrDefault() as ICommand;
        }
    }
}

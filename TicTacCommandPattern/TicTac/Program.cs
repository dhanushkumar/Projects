using Microsoft.Extensions.DependencyInjection;
using System;
using TicTac.Calculator;

namespace Calculator
{
    class Program
    {
        /// <summary>
        /// Program to check divisibility
        /// </summary>
        /// <param name="args"></param>
        static void Main(string[] args)
        {
  
            RunMethodOne(); //uncomment to run this method

            //buid service provider
            var serviceProvider = new ServiceCollection()
            .AddSingleton<ICalculatorService, CalculatorService>()
            .BuildServiceProvider();
            var service = serviceProvider.GetService<ICalculatorService>();
            //inject service
          // RunMethodTwo(service);
        }

        /// <summary>
        /// Method 1 - using dependency injection / Command pattern
        /// </summary>
        private static void RunMethodOne()
        {
            
            var receiver = new WriteToConsoleReceiver();
            //result dependency is injected to the command. This will write out to the console once the command is executed
            var devisibilityCheckCommand = new DivisibilityCheckCommand(receiver);
            //input dependency is accepted by the command
            devisibilityCheckCommand.Accept(new InputNumber { Value = 3, Alias = "TIC" });
            devisibilityCheckCommand.Accept(new InputNumber { Value = 5, Alias = "TAC" });

            for (int i = 0; i < 100; i++)
            {
                //set the value that requires testing against the input
                devisibilityCheckCommand.CurrentIteration = i;// change
                devisibilityCheckCommand.Execute();
            }
            Console.ReadLine();
        }

        /// <summary>
        /// Method 2 Using dependency injection as a service
        /// </summary>
        private static void RunMethodTwo(ICalculatorService service)
        {
            var devisibilityCommand = GetDivisibilityCommand();
            var fibonacciCommand = GetFibonacciCommand();
            //inject command(s)
            service.Add(devisibilityCommand);
            service.Add(fibonacciCommand);
            //let service invoke the command
            service.Run();
            Console.ReadLine();
        }

        private static ICommand GetFibonacciCommand()
        {
            var fibbonacciReceiver = new FibonacciSequenceResultReceiver();
            var fibonacciCommand = new FibonacciSequenceCommand(fibbonacciReceiver);
            fibonacciCommand.Accept(new InputNumber { Value = 0 });
            fibonacciCommand.Accept(new InputNumber { Value = 1 });
            fibonacciCommand.Set(25);
            return fibonacciCommand;

        }

        private static ICommand GetDivisibilityCommand()
        {
            var receiver = new WriteToConsoleReceiver();
            //result dependency is injected to the command. This will write out to the console once the command is executed
            var devisibilityCheckCommand = new DivisibilityCheckCommand(receiver);
            //input dependency is(are) accepted by the command. 
            devisibilityCheckCommand.Accept(new InputNumber { Value = 3, Alias = "tic" });
            devisibilityCheckCommand.Accept(new InputNumber { Value = 5, Alias = "tac" });
            //set the number of iterations for this command
            devisibilityCheckCommand.Set(100);
            return devisibilityCheckCommand;

        }
    }
}

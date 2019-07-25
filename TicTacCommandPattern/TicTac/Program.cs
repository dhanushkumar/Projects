using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
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
            //DI without IoC
            //RunMethodOne(); //uncomment to run this method

            var service = new CalculatorService();
            service.AddCommand(new DivisibilityCheckCommand(new DivisibilityResultReceiver()));
            service.AddCommand(new FibonacciSequenceCommand(new DefaultResultReceiver()));
            service.AddCommand(new PrintEvenNumbersCommand(new DefaultResultReceiver()));

            var serviceProvider = new ServiceCollection()
            .AddSingleton<ICalculatorService>(option => service)
            .BuildServiceProvider();

            //DI and access just the registered service. Commands are injected manually in the methods
            //RunMethodTwo(serviceProvider.GetService<ICalculatorService>());

            //run using inversion of control principle - Dependency injection. The service and commands are readily available for access
            RunUsingInversionOfControl(serviceProvider);
        }

        /// <summary>
        /// Method 1 - using dependency injection / Command pattern
        /// </summary>
        private static void RunMethodOne()
        {
            
            var receiver = new DivisibilityResultReceiver();
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
        /// Method 3 Using dependency injection and Inversion of Control principle
        /// </summary>
        private static void RunUsingInversionOfControl(ServiceProvider serviceCollection)
        {
            //access registered service(s) from DI IoC
            var service = serviceCollection.GetService<ICalculatorService>();
            //access registered command(s) from the servive
            var command = service.GetCommand<DivisibilityCheckCommand>();
            //plugin data for calculation to be performed
            command.Accept(new InputNumber { Value = 3, Alias = "tic" });
            command.Accept(new InputNumber { Value = 5, Alias = "tac" });
            //set required iterations to be performed
            command.SetIterations(100);
            //let the service invoke command(s)
            service.Run();
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
            service.AddCommand(devisibilityCommand);
            service.AddCommand(fibonacciCommand);
            //let service invoke the command
            service.Run();
            Console.ReadLine();
        }

      

        private static ICommand GetDivisibilityCommand()
        {
            var receiver = new DivisibilityResultReceiver();
            //result dependency is injected to the command. This will write out to the console once the command is executed
            var devisibilityCheckCommand = new DivisibilityCheckCommand(receiver);
            //input dependency is(are) accepted by the command. 
            devisibilityCheckCommand.Accept(new InputNumber { Value = 3, Alias = "tic" });
            devisibilityCheckCommand.Accept(new InputNumber { Value = 5, Alias = "tac" });
            //set the number of iterations for this command
            devisibilityCheckCommand.SetIterations(100);
            return devisibilityCheckCommand;
        }

        private static ICommand GetFibonacciCommand()
        {
            var fibbonacciReceiver = new DefaultResultReceiver();
            var fibonacciCommand = new FibonacciSequenceCommand(fibbonacciReceiver);
            fibonacciCommand.Accept(new InputNumber { Value = 0 });
            fibonacciCommand.Accept(new InputNumber { Value = 1 });
            fibonacciCommand.SetIterations(25);
            return fibonacciCommand;
        }

       
    }
}

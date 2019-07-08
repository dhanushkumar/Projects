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
  
            //RunMethodOne(); //uncomment to run this method

            //buid service provider
            var serviceProvider = new ServiceCollection()
            .AddSingleton<ICalculatorService, CalculatorService>()
            .BuildServiceProvider();
            var service = serviceProvider.GetService<ICalculatorService>();
            //inject service
            RunMethodTwo(service);

        }


        /// <summary>
        /// Method 1 - using dependency injection / Command pattern
        /// </summary>
        private static void RunMethodOne()
        {
            
            var resultReceiver = new ResultReceiver();
            //result dependency is injected to the command. This will write out to the console once the command is executed
            var devisibilityCheckCommand = new DivisibilityCheckCommand(resultReceiver);
            //input dependency is accepted by the command
            devisibilityCheckCommand.Accept(new RightInput { Value = 3, Alias = "TIC" });
            devisibilityCheckCommand.Accept(new RightInput { Value = 5, Alias = "TAC" });

            for (int i = 0; i < 100; i++)
            {
                //set the value that requires testing against the input
                devisibilityCheckCommand.Set(i);
                devisibilityCheckCommand.Execute();
            }
            Console.ReadLine();
        }

        /// <summary>
        /// Method 2 Using dependency injection as a service
        /// </summary>
        private static void RunMethodTwo(ICalculatorService service)
        {
            var resultReceiver = new ResultReceiver();
            //result dependency is injected to the command. This will write out to the console once the command is executed
            var devisibilityCheckCommand = new DivisibilityCheckCommand(resultReceiver);
            //input dependency is(are) accepted by the command. 
            devisibilityCheckCommand.Accept(new RightInput { Value = 3, Alias = "tic" });
            devisibilityCheckCommand.Accept(new RightInput { Value = 5, Alias = "tac" });
            //sets the number of iterations
            service.Set(100);
            //inject command(s)
            service.Add(devisibilityCheckCommand);
            //let the service invoke the command
            service.Start();
            Console.ReadLine();
        }
    }
}

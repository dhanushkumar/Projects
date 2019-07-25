using System;
namespace TicTac.Calculator
{
    /// <summary>
    /// Result receiver 
    /// </summary>
    public class DefaultResultReceiver : IReceiver
    {
            public void Process(INumber resultNumber)
            {
                WriteToConsole(resultNumber);
            }

            private void WriteToConsole(INumber resultNumber)
            {
                Console.WriteLine(string.Format("{0}", resultNumber.Value));
                
            }
    }
}

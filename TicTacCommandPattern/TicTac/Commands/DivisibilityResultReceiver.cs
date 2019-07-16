using System;
namespace TicTac.Calculator
{
    /// <summary>
    /// Result receiver 
    /// </summary>
    public class DivisibilityResultReceiver : IReceiver
    {
            public void Process(INumber resultNumber)
            {
                WriteToConsole(resultNumber);
            }

            private void WriteToConsole(INumber resultNumber)
            {
                if (!string.IsNullOrEmpty(resultNumber.Alias))
                {
                    Console.WriteLine(string.Format("{0} {1}", resultNumber.Value, resultNumber.Alias));
                }
            }
    }
}

using System;
namespace TicTac.Calculator
{
    /// <summary>
    /// Result receiver 
    /// </summary>
    public class ResultReceiver : IReceiver
    {
            public void WriteToConsole(INumber resultNumber)
            {
                if(!string.IsNullOrEmpty(resultNumber.Alias))
                {
                  Console.WriteLine(string.Format("{0} {1}", resultNumber.Value, resultNumber.Alias));
                }
            }
        }
}

using System;
using System.Collections.Generic;
using System.Linq;

namespace TicTac.Calculator
{
    public interface ICalculatorService
    {
       void Run();
       void Add(ICommand command);
       
    }
}

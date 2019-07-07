using System;
using System.Collections.Generic;
using System.Linq;

namespace TicTac.Calculator
{
    public interface ICalculatorService: IIterationJob
    {
       void Start();
       void Add(ICommand command);
       
    }
}

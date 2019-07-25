using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TicTac.Calculator;

namespace TicTacTest
{
    internal static class MockObjects
    {
        public  class MockReceiver : IReceiver
        {
            public Result OutResult ;
            public void Process(INumber result)
            {
                OutResult = result as Result;
            }
        }

       
    }

    
}

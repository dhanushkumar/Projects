using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TicTac;
using TicTac.Calculator;

namespace TicTacTest
{
    /// <summary>
    /// due to time constraint, only the core functionality is unit tested
    /// </summary>
    [TestClass]
    public class DivisibilityCheckCommandTest
    {


        [TestMethod]
        public void TicTacTest()
        {
            var resultReceiver = new MockObjects.MockReceiver();
            var devisibilityCheckCommand = new DivisibilityCheckCommand(resultReceiver);
            devisibilityCheckCommand.Accept(new InputNumber { Value = 3, Alias = "tic" });
            devisibilityCheckCommand.Accept(new InputNumber { Value = 5, Alias = "tac" });
            devisibilityCheckCommand.CurrentIteration = 15;
            devisibilityCheckCommand.Execute();
            Assert.AreEqual("TIC TAC", resultReceiver.OutResult.Alias);
        }

        [TestMethod]
        public void TicTest()
        {
            var resultReceiver = new MockObjects.MockReceiver();
            var devisibilityCheckCommand = new DivisibilityCheckCommand(resultReceiver);
            devisibilityCheckCommand.Accept(new InputNumber { Value = 3, Alias = "tic" });
            devisibilityCheckCommand.CurrentIteration = 15;
            devisibilityCheckCommand.Execute();
            Assert.AreEqual("TIC", resultReceiver.OutResult.Alias);
         
        }

        [TestMethod]
        public void TacTest()
        {
            var resultReceiver = new MockObjects.MockReceiver();
            var devisibilityCheckCommand = new DivisibilityCheckCommand(resultReceiver);
            devisibilityCheckCommand.Accept(new InputNumber { Value = 5, Alias = "tac" });
            devisibilityCheckCommand.CurrentIteration = 5;
            devisibilityCheckCommand.Execute();
            Assert.AreEqual("TAC", resultReceiver.OutResult.Alias);
          
        }
        [TestMethod]
        public void ResultReceiverWriteToConsoleTest()
        { using (StringWriter sw = new StringWriter())
            {
                Console.SetOut(sw);
                var testReciever = new DivisibilityResultReceiver();
                testReciever.Process(new Result { Alias = "TIC", Value = 6 });
                var testRecieverContent = sw.ToString();
                Assert.AreEqual(string.Format("6 TIC{0}", Environment.NewLine),testRecieverContent);
            }

        }

    }
}

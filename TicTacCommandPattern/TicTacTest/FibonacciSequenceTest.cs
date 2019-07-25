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
    public class FibonacciSequenceTest
    {


        [TestMethod]
        public void SequenceTest()
        {
            var resultReceiver = new MockObjects.MockReceiver();
            var fibonacciCommand = new FibonacciSequenceCommand(resultReceiver);
            fibonacciCommand.Accept(new InputNumber { Value = 0 });
            fibonacciCommand.Accept(new InputNumber { Value = 1 });
            fibonacciCommand.Execute();
            Assert.AreEqual(1, resultReceiver.OutResult.Value);
        }

        [TestMethod]
        public void LessThanTwoInputTest()
        {
            var resultReceiver = new MockObjects.MockReceiver();
            var fibonacciCommand = new FibonacciSequenceCommand(resultReceiver);
            fibonacciCommand.Accept(new InputNumber { Value = 1 });
            fibonacciCommand.Execute();
            Assert.IsNull(resultReceiver.OutResult);
        }

        [TestMethod]
        public void TwoOrMoreInputTest()
        {
            var resultReceiver = new MockObjects.MockReceiver();
            var fibonacciCommand = new FibonacciSequenceCommand(resultReceiver);
            fibonacciCommand.Accept(new InputNumber { Value = 1 });
            fibonacciCommand.Accept(new InputNumber { Value = 2 });
            fibonacciCommand.Execute();
            Assert.IsNotNull(resultReceiver.OutResult);
        }


        [TestMethod]
        public void ZeroValueTest()
        {
            var resultReceiver = new MockObjects.MockReceiver();
            var fibonacciCommand = new FibonacciSequenceCommand(resultReceiver);
            fibonacciCommand.Accept(new InputNumber { Value = 0 });
            fibonacciCommand.Accept(new InputNumber { Value = 0 });
            fibonacciCommand.Execute();
            Assert.AreEqual(0, resultReceiver.OutResult.Value);
        }

    }
}

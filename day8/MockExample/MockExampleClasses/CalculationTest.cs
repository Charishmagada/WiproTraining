using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Moq;
using NUnit.Framework;

namespace MockExampleClasses
{
    [TestFixture]
    internal class CalculationTest
    {
        [Test]
        public void TestSum()
        {
            Mock<Calculation>mockObject=new Mock<Calculation>();
            mockObject.Setup(x => x.Sum(12,5)).Returns(17);
            Assert.AreEqual(17,mockObject.Object.Sum(12,5));

        }
        [Test]
        public void TestSub()
        {
           Mock<Calculation>mockObject= new Mock<Calculation>();
            mockObject.Setup(x => x.Sub(12, 5)).Returns(7);
            Assert.AreEqual(7,mockObject.Object.Sub(12,5));

        }
        public void TestMul()
        {
            Mock<Calculation>mockObject=new Mock<Calculation>();
            mockObject.Setup(x => x.Mul(12, 5)).Returns(60);
            Assert.AreEqual(60,mockObject.Object.Mul(12,5));    
        }


    }
}

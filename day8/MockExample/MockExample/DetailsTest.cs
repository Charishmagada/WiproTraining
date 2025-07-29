using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Moq;
using NUnit.Framework;

namespace MockExample
{
    [TestFixture]
    public class DetailsTest
    {
        [Test]
        public void TestShowCompany()
        {
            Mock<IDetails>mockDetails=new Mock<IDetails>();
            mockDetails.Setup(d => d.ShowCompany()).Returns("Wipro Hyderabad");
            Assert.AreEqual("Wipro Hyderabad",mockDetails.Object.ShowCompany());
        }
        [Test]
        public void TestShowName()
        {
            Mock<IDetails>obj=new Mock<IDetails>();
            obj.Setup(d => d.ShowName()).Returns("I am Tripura");
            Assert.AreEqual("I am Tripura", obj.Object.ShowName());
        }
    }
}

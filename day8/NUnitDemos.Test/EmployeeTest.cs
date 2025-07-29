using NunitDemos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NUnitDemos.Test
{
    [TestFixture]
    internal class EmployeeTest
    {
        [Test]
        public void TestSearchEmploy()
        {
            EmployeeDao employDao = new EmployeeDao();
            Employee employFound = employDao.SearchEmployee(1);
            Assert.IsNotNull(employFound);
            employFound = employDao.SearchEmployee(-1);
            Assert.Null(employFound);
        }

        [Test]
        public void TestShowEmploy()
        {
            List<Employee> employList = new EmployeeDao().ShowEmployee();
            Assert.AreEqual(4, employList.Count);
        }

        [Test]
        public void TestToString()
        {
            Employee employ = new Employee();
            employ.Empno = 1;
            employ.Name = "Girish";
            employ.Basic = 99422;

            string expected = "Empno 1 Name Girish Basic 99422";
            Assert.AreEqual(expected, employ.ToString());

        }

        [Test]
        public void TestGettersAndSetters()
        {
            Employee employ = new Employee();
            employ.Empno = 10;
            employ.Name = "Rajesh";
            employ.Basic = 88321;

            Assert.AreEqual(10, employ.Empno);
            Assert.AreEqual("Rajesh", employ.Name);
            Assert.AreEqual(88321, employ.Basic);
        }
        [Test]
        public void TestConstructor()
        {
            Employee employ = new Employee();
            Assert.NotNull(employ);
            Employee employ1 = new Employee(88, "Venkata", 99923);
            Assert.AreEqual(88, employ1.Empno);
            Assert.AreEqual("Venkata", employ1.Name);
            Assert.AreEqual(99923, employ1.Basic);
        }
    }
}

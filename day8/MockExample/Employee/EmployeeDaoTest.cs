using Employee;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Moq;
using NUnit.Framework;


namespace Employee
{
    [TestFixture]
    public class EmployeeDaoTest
    {
        List<Employ> employeeList = new List<Employ>()
        {
           new Employ{Empno=1,Name="Akhil",Basic=88323},
           new Employ{Empno=2,Name="Yash",Basic=91911},
           new Employ { Empno = 3, Name = "Manali", Basic = 86444 },
         };
        Employ e1 = new Employ { Empno = 1, Name = "Prathyusha", Basic = 84234 };
        Employ e2 = new Employ { Empno = 2, Name = "Rohith", Basic = 82234 };

        Employ e3 = null;
        [Test]
        public void TestShowEmployeeList()
        {
            Mock<IEmployeeDao> mockDao = new Mock<IEmployeeDao>();
            mockDao.Setup(x => x.ShowEmployee()).Returns(employeeList);
            Assert.AreEqual(3, mockDao.Object.ShowEmployee().Count);
        }
        public void TestSearchEmployeeList()
        {
            Mock<IEmployeeDao> mockDao = new Mock<IEmployeeDao>();
            mockDao.Setup(x => x.SearchEmployee(1)).Returns(e1);
            Assert.IsNotNull(mockDao.Object.SearchEmployee(1));
            mockDao.Setup(x => x.SearchEmployee(100)).Returns(e2);
            Assert.IsNotNull(mockDao.Object.SearchEmployee(100));
            mockDao.Setup(x => x.SearchEmployee(200)).Returns(e3);
            Assert.IsNull(mockDao.Object.SearchEmployee(200));
        }


    }
}

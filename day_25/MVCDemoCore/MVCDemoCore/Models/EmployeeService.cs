namespace MVCDemoCore.Models
{
    public class EmployeeService
    {
        private static List<Employee> employList = null;

        static EmployeeService()
        {
            employList = new List<Employee>();
            employList.Add(new Employee
            {
                Empno = 101,
                Name = "Anil Patil",
                Basic = 488234
            });
            employList.Add(new Employee
            {
                Empno = 102,
                Name = "Rajesh",
                Basic = 900321
            });
            employList.Add(new Employee
            {
                Empno = 103,
                Name = "Sreeja V",
                Basic = 488234
            });
            employList.Add(new Employee
            {
                Empno = 104,
                Name = "Yashwanth V",
                Basic = 488234
            });
            employList.Add(new Employee
            {
                Empno = 105,
                Name = "Vivek Vardhan",
                Basic = 488234
            });
            employList.Add(new Employee
            {
                Empno = 106,
                Name = "Prachi",
                Basic = 902332
            });
            employList.Add(new Employee
            {
                Empno = 107,
                Name = "Srivalli",
                Basic = 900322
            });
            employList.Add(new Employee
            {
                Empno = 108,
                Name = "Mahesh",
                Basic = 900211
            });
        }

        public bool AddEmploy(Employee newEmploy)
        {
            bool EmployAdded = false;
            int oldCount = employList.Count;
            employList.Add(newEmploy);
            int newCount = employList.Count;
            if (newCount > oldCount)
                EmployAdded = true;
            return EmployAdded;
        }

        public List<Employee> GetAllEmploys()
        {
            return employList;
        }


        public Employee ShowEmploy(int empno)
        {
            return employList.First(g => g.Empno == empno);
        }

        public Employee UpdateEmploy(Employee updateEmploy)
        {
            Employee employ = employList.First(g => g.Empno == updateEmploy.Empno);
            employ.Name = updateEmploy.Name;
            employ.Basic = updateEmploy.Basic;
            return employ;
        }
        public bool DeleteEmploy(int id)
        {
            Employee gs = employList.First(g => g.Empno == id);
            return employList.Remove(gs);
        }

    }
}
    


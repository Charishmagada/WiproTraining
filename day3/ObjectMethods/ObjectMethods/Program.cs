using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ObjectMethods
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Employee e1 = new Employee(1,"Siri",8883422);
            Console.WriteLine(e1);
            // when we execute without ToString we get ObjectMethods.Employee as op
            Employee e2 = new Employee(2, "padma", 9988332);
            Console.WriteLine(e2);


            //for student example

            Student[] studentArray = new Student[]
           {
                new Student(1,"Siri",9.2,"Hyderabad"),
                new Student(2,"Padma",8.9,"Vijayanagaram"),
                new Student(3, "Anantha",9.1,"Rajahmundry")
           };

            foreach (Student student in studentArray)
            {
                Console.WriteLine(student);
            }

        }
    }
}

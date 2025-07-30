using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Reflection
{
    internal class Student
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public double Cgpa {  get; set; }
        public Student()
        {
            Id = 0;
            Name = "tara";
            Cgpa = 0.0;
        }
        public Student(int id, string name, double cgpa)
        {
            Id = id;
            Name = name;
            Cgpa = cgpa;
        }
        public override string ToString()
        {
            return "Sid " + Id + " Name " + Name + " Cgp " + Cgpa;
        }
        public void ShowStudent()
        {
            Console.WriteLine("i am tara");
        }
        public void DeleteStudent(int sid)
        {
            Console.WriteLine("Delete Student " + sid);
        }
        public void SearchStudent(int sid)
        {
            Console.WriteLine("Search Student  " + sid);
        }

        public void AddStudent(Student student)
        {
            Console.WriteLine("Please Add Student...");
        }
    }
}

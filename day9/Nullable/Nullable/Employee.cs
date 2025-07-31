using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Nullable
{
    public class Employee
    {
        public int Empno {  get; set; }
        public string Name { get; set; }
        public double Basic {  get; set; }
        public int? LeaveDays {  get; set; }
        public Nullable<int>Status { get; set; }
    }
}

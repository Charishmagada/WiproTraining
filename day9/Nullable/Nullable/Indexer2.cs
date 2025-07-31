using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nullable
{
    internal class Indexer2
    {
        Emp[] arr=new Emp[5];
        public Emp this[int id]
        {
            get
            {
                return arr[id];
            }
            set
            {
                arr[id] = value;
            }
        }
        static void Main()
        {
            Indexer2 obj = new Indexer2();
            obj[0] = new Emp { Empno = 1, Name = "Padma", Basic = 99899 };
            obj[1] = new Emp { Empno = 2, Name = "Tripura", Basic = 99888 };
            obj[2] = new Emp { Empno = 3, Name = "Nireesha", Basic = 99778 };
            obj[3] = new Emp { Empno = 4, Name = "Vijju", Basic = 99776 };
            foreach (var v in obj.arr)
            {
                Console.WriteLine(v);
            }
        }
    }
}

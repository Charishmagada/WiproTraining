using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nullable
{
    public class Demo
    {
        public string[] names = new string[5];
        public string this[int i]
        {
            get
            {
                return names[i];
            }
            set
            {
                names[i] = value;
            }
        }

    }
    public class Indexer1
    {
        static void Main()
        {
            Demo demo= new Demo();
            demo[0] = "Padma";
            demo[1] = "Tripura";
            demo[2] = "Nireesha";
            demo[3] = "Vijju";
            demo[4] = "Praneetha";
            Console.WriteLine("Data is:");
            foreach(var v in demo.names)
            {
                Console.WriteLine(v);
            }
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Appdemo
{
    internal class BoxingCustom
    {
        public void Show(object ob)
        {
            string type=ob.GetType().Name;
            Console.WriteLine(type);
            if(type.Equals("Int32"))
            {
                int x=(Int32)ob;
                Console.WriteLine("Integer casting:" + x);
            }
            if(type.Equals("String"))
            {
                string x=(string)ob;
                Console.WriteLine("String casting:" + x);
            }
            if(type.Equals("Double"))
            {
                double x=(double)ob;
                Console.WriteLine("Double casting:"+x);

            }

        }
        static void Main()
        {
            int x = 7;
            string str = "wipro";
            double y = 12.37;
            BoxingCustom boxing = new BoxingCustom();
            boxing.Show(x);
            boxing.Show(str);
            boxing.Show(y);


        }
    }
}

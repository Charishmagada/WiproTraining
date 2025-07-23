using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Appdemo
{
    internal class ArrStr
    {
        public void Show()
        {
            string[] names = new string[]
            {
                "Charishma","Padma","Siri"
            };
            foreach (string name in names) {
                Console.WriteLine(name);
            }
        }
        static void Main(string[] args) {
            ArrStr arrStr = new ArrStr();
            arrStr.Show();
        }
    }
}

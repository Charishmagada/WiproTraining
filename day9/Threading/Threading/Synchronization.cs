using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Threading
{
    class Data
    {
        public void Show(string Name)
        {
            lock (this)
            {
                Console.Write("Hello " + Name);
                Thread.Sleep(1000);
                Console.WriteLine(" How are you?"); 
            }
        }
    }
    public class Synchronization
    {
        Data data;
        Synchronization(Data data)
        {
            this.data = data;
        }
        public void Siri()
        {
            data.Show("siri");
        }
        public void Padma()
        {
            data.Show("padma");
        }

        static void Main()
        {
           Synchronization synchronization=new Synchronization(new Data());
            synchronization.Siri();
            ThreadStart th1 =new ThreadStart(synchronization.Padma);
            ThreadStart th2=new ThreadStart(synchronization.Siri);
            Thread t1 = new Thread(th1);
            Thread t2 = new Thread(th2);

            t1.Start();
            t2.Start();

        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SolidPrinciples
{
    internal class WithLSP
    {
        public abstract class Bird { }

        public interface IFlyingBird
        {
            void Fly();
        }

        public class Sparrow : Bird, IFlyingBird
        {
            public void Fly() => Console.WriteLine("Sparrow Flying");
        }

        public class Ostrich : Bird
        {
            // No Fly method — no problem
        }

    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SolidPrinciples
{
    public class WithoutLSP
    {
        public class Bird
        {
            public virtual void Fly() => Console.WriteLine("Flying");
        }

        public class Sparrow : Bird { }

        public class Ostrich : Bird
        {
            public override void Fly() => throw new NotSupportedException();
        }
        static void Main()
        {
            List<Bird> birds = new List<Bird>
            {
                new Sparrow(),
                new Ostrich()
            };

            foreach (var bird in birds)
            {
                try
                {
                    bird.Fly();  // This will throw exception for Ostrich
                }
                catch (NotSupportedException)
                {
                    Console.WriteLine($"{bird.GetType().Name} cannot fly!");
                }
            }
        }

    }
}

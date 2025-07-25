using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExceptionHandling
{
    internal class Voting
    {
        public void Show(int age)
        {
            if(age<18)
            {
                throw new VotingException("Age is small,not eligible for voting");
            }
            else
            {
                Console.WriteLine("Eligible for voting");
            }
        }
        static void Main()
        {
            int age;
            Console.WriteLine("Enter age:");
            age=Convert.ToInt32(Console.ReadLine());
            Voting voting = new Voting();
            try
            {
                voting.Show(age);
            }
            catch(VotingException e)
            {
                Console.WriteLine(e.Message);
            }
            catch (Exception e)
            {

                Console.WriteLine(e.Message);
            }
        }
    }
}

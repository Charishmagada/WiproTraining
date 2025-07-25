﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace ExceptionHandling
{
    internal class Division
    {
        static void Main(string[] args)
        {
            int a, b, c;
            Console.WriteLine("Enter 2 numbers:");

            try
            {
                a = Convert.ToInt32(Console.ReadLine());
                b = Convert.ToInt32(Console.ReadLine());
                c = a / b;
                Console.WriteLine("Value after division: " + c);
            }
            catch (OverflowException)
            {
                Console.WriteLine("Number out of range");
            }
            catch(FormatException )
            {
                Console.WriteLine("Only integers are allowed as inputs");
            }
            catch(DivideByZeroException )
            {
                Console.WriteLine("Division by zero is impossible");
            }
            catch (Exception e)
            {
                Console.WriteLine(e);// exception generated by system.we can also have user define exceptions
                Console.WriteLine(e.Message);
            }
            finally
                {
                Console.WriteLine("Wipro");
            }
        }
    }
}

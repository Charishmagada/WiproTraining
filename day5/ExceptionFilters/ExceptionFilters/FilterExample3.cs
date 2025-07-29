using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExceptionFilters
{
    internal class FilterExample3
    {
        static void ShowMilestoneInfo(string examcode)
        {
            if(examcode.Equals("M1"))
            {
                throw new FilterExceptionUserDefined("Milestone1 contains .NET");
            }
            else if(examcode.Equals("M2"))
            {
                throw new FilterExceptionUserDefined("Milestone2 contains react");
            }
            else if(examcode.Equals("M3"))
            {
                throw new FilterExceptionUserDefined("Milestone3 contains .ASP");
            }
            else if(examcode.Equals("M4"))
            {
                throw new FilterExceptionUserDefined("Milestone4 contains database");
            }
            else if(examcode.Equals("M5"))
            {
                throw new FilterExceptionUserDefined("Capstone Project");
            }
        }
        static void Main()
        {
            string examCode;
            Console.WriteLine("Enter Exam Code:");
            examCode = Console.ReadLine();
            try
            {
                ShowMilestoneInfo(examCode);

            }
            catch (FilterExceptionUserDefined e) when (e.Message.Contains("Milestone1"))
            {
                Console.WriteLine(e.Message);
            }
            catch (FilterExceptionUserDefined e) when (e.Message.Contains("Milestone2"))
            {
                Console.WriteLine(e.Message);
            }
            catch (FilterExceptionUserDefined e) when (e.Message.Contains("Milestone3"))
            {
                Console.WriteLine(e.Message);
            }
            catch (FilterExceptionUserDefined e) when (e.Message.Contains("Milestone4"))
            {
                Console.WriteLine(e.Message);
            }
            catch (FilterExceptionUserDefined e) when (e.Message.Contains("Project"))
            {
                Console.WriteLine(e.Message);
            }
            catch(Exception e)
            {
                Console.WriteLine(e);
            }
        }
    }
}

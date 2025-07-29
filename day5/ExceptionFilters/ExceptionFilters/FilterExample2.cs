using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExceptionFilters
{
    internal class FilterExample2
    {
        static void RaiseSeverity(string severity)
        {
            if (severity.Equals("low"))
            {
                throw new FilterExceptionUserDefined("low severity you can leave");
            }
            else if (severity.Equals("mediun"))
            {
                throw new FilterExceptionUserDefined("medium severity you need to try without leaving");
            }
            else if(severity.Equals("high"))
            {
                throw new FilterExceptionUserDefined("high severity you need to fix asap");
            }
            else if(severity.Equals("critical"))
            {
                throw new FilterExceptionUserDefined("critical error,you must fix");
            }
            else
            {
                throw new FilterExceptionUserDefined("no error occured");
            }

        }
        static void Main()
        {
            string severity;
            Console.WriteLine("Enter severity situation:");
            severity = Console.ReadLine();
            try
            {
                RaiseSeverity(severity);
            }
            catch (FilterExceptionUserDefined e)when (e.Message.Contains("low"))
            {
                Console.WriteLine(e.Message);
            }
            catch(FilterExceptionUserDefined e)when (e.Message.Contains("medium"))
            {
                Console.WriteLine(e.Message);
            }
            catch(FilterExceptionUserDefined e)when(e.Message.Contains("high"))
            {
                Console.WriteLine(e.Message);
            }
            catch(FilterExceptionUserDefined e)when(e.Message.Contains("critical"))
            {
                Console.WriteLine(e.Message);
            }
            catch(FilterExceptionUserDefined e)
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

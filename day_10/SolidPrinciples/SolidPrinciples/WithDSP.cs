using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SolidPrinciples
{
    internal class WithDSP
    {
        public interface IMessageSender
        {
            void Send(string message);
        }
        public class EmailSender : IMessageSender
        {
            public void Send(string message)
            {
                Console.WriteLine("Email: " + message);
            }
        }

        public class SMSSender : IMessageSender
        {
            public void Send(string message)
            {
                Console.WriteLine("SMS: " + message);
            }
        }
        static void SendNotification(IMessageSender sender, string message)
        {
            sender.Send(message);
        }
        static void Main()
        {
           
                IMessageSender emailSender = new EmailSender();
                IMessageSender smsSender = new SMSSender();

                SendNotification(emailSender, "Welcome via Email!");
                SendNotification(smsSender, "Welcome via SMS!");
           

        }


    }
}

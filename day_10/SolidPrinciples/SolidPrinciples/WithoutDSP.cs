using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SolidPrinciples
{
    internal class WithoutDSP
    {
        public class Notification
        {
            public void SendMessage()
            {
                EmailSender email = new EmailSender();
                email.Send("Hello!");
            }
        }

        public class EmailSender
        {
            public void Send(string message)
            {
                Console.WriteLine("Email: " + message);
            }
        }
        static void Main()
        {
            Notification notification = new Notification();
            notification.SendMessage();
            EmailSender emailSender = new EmailSender();
            emailSender.Send("Charishma");
        }
    }
}

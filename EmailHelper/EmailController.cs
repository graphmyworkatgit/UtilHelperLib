using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Net;
using System.Net.Mail;
using EntryPoint.src.Model;

namespace EntryPoint.src.EmailModule
{
    public class EmailController
    {
        public void SendEmail()
        {

            var to = "harishgk201@gmail.com";
            var from = "einfo2021@gmail.com"; //"importantmailtoyourmailbox@gmail.com"; 
            var fromAddress = new MailAddress(from, "From Name");
            var toAddress = new MailAddress(to, "To Name");
            const string fromPassword = "B00mB00m";
            const string subject = "Subject--1`";
            const string body = "Body";

            var smtp = new SmtpClient
            {
                Host = "smtp.gmail.com",
                Port = 587,
                EnableSsl = true,
                DeliveryMethod = SmtpDeliveryMethod.Network,
                UseDefaultCredentials = false,
                Credentials = new NetworkCredential(fromAddress.Address, fromPassword)
            };
            try
            {
                using (var message = new MailMessage(fromAddress, toAddress)
                {
                    Subject = subject,
                    Body = body
                })
                {
                    smtp.Send(message);
                }
            }
            catch(Exception e)
            {
                Console.WriteLine(e);
            }

        }

        public int SendEmail(Email email)
        {

            
            var fromAddress = new MailAddress(email.FromAddress, email.FromName);
            var toAddress = new MailAddress(email.ToAddress, email.ToName);
            
          

            var smtp = new SmtpClient
            {
                Host = "smtp.gmail.com",
                Port = 587,
                EnableSsl = true,
                DeliveryMethod = SmtpDeliveryMethod.Network,
                UseDefaultCredentials = false,
                Credentials = new NetworkCredential(fromAddress.Address, email.FromAdmin.FromPwd)
            };
            try
            {
                using (var message = new MailMessage(fromAddress, toAddress)
                {
                    Subject = email.EmailSubject,
                    Body = email.EmailBody
                    
                })
                {
                    smtp.Send(message);
                }
                Console.WriteLine("---------------");
                Console.WriteLine(email.EmailBody);
                Console.WriteLine("---------------");
                return 1;
            }
            catch(System.Net.Mail.SmtpException er)
            {
                return -1;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return -2;
            }

        }

        public void GenerateBody()
        {

        }

    }
}

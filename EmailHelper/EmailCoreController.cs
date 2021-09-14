using MimeKit;
using MailKit.Net.Smtp;

using System;
using System.Collections.Generic;
//using System.Net.Mail;
using System.Text;
using UtilHelper.EmailHelper.Model;

using System.Net;
//using System.Net.Mail;

namespace UtilHelper.EmailHelper
{
    public class EmailCoreController
    {
        private MimeMessage CreateMimeMessageFromEmailMessage(EmailMessage message)
        {
            var mimeMessage = new MimeMessage();
            mimeMessage.From.Add(message.Sender);
            mimeMessage.To.
                Add(message.Receiver);
            mimeMessage.Subject = message.Subject;
            mimeMessage.Body = new TextPart(MimeKit.Text.TextFormat.Text)
            {
                Text = message.Content
            };
            return mimeMessage;
        }
        public void SendEmail()
        {
            using (SmtpClient smtpClient = new SmtpClient())
            {
                NotificationMetadata _notificationMetadata =
                    new NotificationMetadata();

                smtpClient.Connect(_notificationMetadata.SmtpServer,
                    _notificationMetadata.Port, true);

                smtpClient.Authenticate(_notificationMetadata.UserName,
                    _notificationMetadata.Password);
                var t = new EmailMessage()
                {

                };
                smtpClient.Send(CreateMimeMessageFromEmailMessage(t));
                smtpClient.Disconnect(true);

            }
        }
            public string Get()
            {
                EmailMessage message = new EmailMessage();
                NotificationMetadata _notificationMetadata =
                  new NotificationMetadata();

                message.Sender = 
                    new MailboxAddress("Self", _notificationMetadata.Sender);
                message.Receiver =
                    new MailboxAddress("Self", _notificationMetadata.Receiver);
                message.Subject = "Welcome";
                message.Content = "Hello World!";
                var mimeMessage = CreateMimeMessageFromEmailMessage(message);

            using (SmtpClient smtpClient = new SmtpClient())
            {
                NotificationMetadata _notificationMetadata1 =
                    new NotificationMetadata();
                
                smtpClient.Connect(_notificationMetadata1.SmtpServer,
                    _notificationMetadata.Port, true);

                smtpClient.Authenticate(_notificationMetadata1.UserName,
                    _notificationMetadata1.Password);
                var t = new EmailMessage()
                {

                };
                smtpClient.Send(mimeMessage);
                smtpClient.Disconnect(true);

            }

            return "Email Sent Successfully";
            }
        
    }
}

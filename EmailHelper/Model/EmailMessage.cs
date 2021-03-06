using MimeKit;
using System;
using System.Collections.Generic;
using System.Text;

namespace UtilHelper.EmailHelper.Model
{
    /// <summary>
    /// Nuget packages needed MimeKit
    /// </summary>
    public class EmailMessage
    {
        public MailboxAddress Sender { get; set; }
        public MailboxAddress Receiver { get; set; }
        public string Subject { get; set; }
        public string Content { get; set; }
    }
}

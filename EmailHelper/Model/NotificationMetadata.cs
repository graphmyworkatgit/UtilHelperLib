﻿using System;
using System.Collections.Generic;
using System.Text;

namespace UtilHelper.EmailHelper.Model
{
    public class NotificationMetadata
    {
        public string Sender { get; set; }
        public string Receiver { get; set; }
        public string SmtpServer { get; set; }
        public int Port { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
    }
}

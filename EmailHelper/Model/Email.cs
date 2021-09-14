using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntryPoint.src.Model
{
    public class Email
    {
        public string FromAddress { get; set; }
        public string ToAddress { get; set; }
        public string FromName { get; set; }
        public string ToName { get; set; }

        public EmailAdmin FromAdmin { get; set; } = new EmailAdmin() { };

        public string EmailSubject { get; set; }

        public string EmailBody { get; set; }
    }
    public class EmailAdmin
    {
        public string FromPwd { get; set; } 

        public EmailAdmin()
        {
            FromPwd = "B00mB00m";
        }

    }
}

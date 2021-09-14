using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;
using System.Web.UI;




namespace EmailTemplate
{
    class EmailTemplate
    {
        /*
       public MailMessage GetBody()
        {
            string toAddr = "einfo2021@gmail.com";
            MailDefinition md = new MailDefinition();
            md.From = "einfo2021@gmail.com";
            md.IsBodyHtml = true;
            md.Subject = "Test of MailDefinition";

            ListDictionary replacements = new ListDictionary();
            replacements.Add("{name}", "Martin");
            replacements.Add("{country}", "Denmark");

            string body = "<div>Hello {name} You're from {country}.</div>";
            MailMessage msg=null;

            try
            {
                msg = md.CreateMailMessage(toAddr, replacements, body, new System.Web.UI.Control());
            }
            catch(Exception e)
            {
                Console.WriteLine( $"GetBody() - {e.Message}" );
            }
            return msg;
        }
        */
    }
}

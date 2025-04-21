using System.Net;
using System.Net.Mail;
using System.Threading.Tasks;

namespace WebSite.Core.Utility
{
    public static class MyEmail
    {
       
        public static void SendAccountEmail(MailAddress toAddress, string mailSubject, string mailBody)
        {
            MailAddress fromAddress = new MailAddress("info@ctn-co.com");

            string password = "Mostafa@carbon$1397";
            string host = "webmail.ctn-co.com";

            MailMessage mail = new MailMessage(fromAddress, toAddress);
            SmtpClient client = new SmtpClient
            {
                Port = 25,
                DeliveryMethod = SmtpDeliveryMethod.Network,
                UseDefaultCredentials = false,
                Host = host,
                EnableSsl = false,
                Credentials = new NetworkCredential(fromAddress.ToString(), password)
            };

            mail.Subject = mailSubject;
            mail.Body = mailBody;
            mail.IsBodyHtml = true;

            MailAddress ccEmail1 = new MailAddress("umit_re@yahoo.com.tr");
            MailAddress ccEmail2 = new MailAddress("m.shahamiri@gmail.com");
            MailAddress ccEmail3 = new MailAddress("hamedzarrin2@gmail.com");
            mail.CC.Add(ccEmail1);
            mail.CC.Add(ccEmail2);
            mail.CC.Add(ccEmail3);


            client.Send(mail);
        }

        public static void SendAutoEmail(MailAddress toAddress, string mailSubject, string mailBody)
        {
            MailAddress fromAddress = new MailAddress("no-reply@ctn-co.com");

            string password = "Mostafa@carbon$1398";
            string host = "webmail.ctn-co.com";

            MailMessage mail = new MailMessage(fromAddress, toAddress);
            SmtpClient client = new SmtpClient
            {
                Port = 25,
                DeliveryMethod = SmtpDeliveryMethod.Network,
                UseDefaultCredentials = false,
                Host = host,
                EnableSsl = false,
                Credentials = new NetworkCredential(fromAddress.ToString(), password)
            };

            mail.Subject = mailSubject;
            mail.Body = mailBody;
            mail.IsBodyHtml = true;


            MailAddress ccEmail1 = new MailAddress("m.shahamiri@gmail.com");
            MailAddress ccEmail2 = new MailAddress("hamedzarrin2@gmail.com");
            mail.CC.Add(ccEmail1);
            mail.CC.Add(ccEmail2);


            client.Send(mail);
        }

        public static void SendNewPassword(MailAddress toAddress, string mailSubject, string mailBody)
        {
            MailAddress fromAddress = new MailAddress("no-reply@ctn-co.com");

            string password = "Mostafa@ctb$1399";
            string host = "webmail.ctn-co.com";

            MailMessage mail = new MailMessage(fromAddress, toAddress);
            SmtpClient client = new SmtpClient
            {
                Port = 25,
                DeliveryMethod = SmtpDeliveryMethod.Network,
                UseDefaultCredentials = false,
                Host = host,
                EnableSsl = false,
                Credentials = new NetworkCredential(fromAddress.ToString(), password)
            };

            mail.Subject = mailSubject;
            mail.Body = mailBody;
            mail.IsBodyHtml = true;
            client.Send(mail);
        }

        public static void SendActiveLink(MailAddress toAddress, string mailSubject, string mailBody)
        {
            MailAddress fromAddress = new MailAddress("no-reply@ctn-co.com");

            string password = "Mostafa@carbon$1398";
            string host = "webmail.ctn-co.com";

            MailMessage mail = new MailMessage(fromAddress, toAddress);
            SmtpClient client = new SmtpClient
            {
                Port = 25,
                DeliveryMethod = SmtpDeliveryMethod.Network,
                UseDefaultCredentials = false,
                Host = host,
                EnableSsl = false,
                Credentials = new NetworkCredential(fromAddress.ToString(), password)
            };

            mail.Subject = mailSubject;
            mail.Body = mailBody;
            mail.IsBodyHtml = true;
            client.Send(mail);
        }
    }
}
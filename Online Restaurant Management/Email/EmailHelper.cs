using MimeKit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Threading.Tasks;

namespace sdp2.Email
{
    public class EmailHelper
    {
        public bool SendEmailPasswordReset(string userEmail, string link)
        {


            var message = new MimeMessage();
            message.From.Add(new MailboxAddress("Stellar Kitchen", "stellarkitchen356@gmail.com"));
            message.To.Add(new MailboxAddress("", userEmail));
            message.Subject = "Reset Password";


            message.Body = new TextPart("plain")
            {
                Text = "Here's the Reset Password Link " + link


            };







            try
            {

                using (var client = new MailKit.Net.Smtp.SmtpClient())
                {
                    client.Connect("smtp.gmail.com", 587, false);
                    client.Authenticate("stellarkitchen356@gmail.com", "Stellar@123456");
                    client.Send(message);
                    client.Disconnect(true);
                    return true;
                }
            }

            catch(Exception exception)
            {
               
            }

            return false;

            //    MailMessage mailMessage = new MailMessage();
            //    mailMessage.From = new MailAddress("stellarkitchen356@gmail.com");
            //    mailMessage.To.Add(new MailAddress(userEmail));

            //    mailMessage.Subject = "Password Reset";
            //    mailMessage.IsBodyHtml = true;
            //    mailMessage.Body = link;

            //    SmtpClient client = new SmtpClient();
            //    client.Credentials = new System.Net.NetworkCredential("stellarkitchen356@gmail.com", "Stellar@123456");
            //    client.Host = "smtpout.secureserver.net";
            //    client.Port = 80;

            //    try
            //    {
            //        client.Send(mailMessage);
            //        return true;
            //    }
            //    catch (Exception ex)
            //    {
            //        // log exception
            //    }
            //    return false;
            //}
        }
    }
}
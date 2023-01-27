using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Threading.Tasks;

namespace FirstApplication.MailHeleper
{
    public static class MailHelper
    {
        public static string sendMail(string Title, string Message)
        {
            try
            {
                MailMessage mail = new MailMessage();
                mail.To.Add("khaledjamal274@gmail.com");
                mail.From = new MailAddress("jkhaled497@gmail.com");
                mail.Subject = Title;
                mail.Body = Message;

                SmtpClient smtp = new SmtpClient("smtp.gmail.com", 587);

                smtp.EnableSsl = true;
                smtp.UseDefaultCredentials = false;
                smtp.Credentials = new NetworkCredential("jkhaled497@gmail.com", "KHALEDJAMAL");
                smtp.Send(mail);
                return "Emai Sende";

            }
            catch (Exception ex)
            {
                return "Mail Faild" + ex;
            }
        }
    }
}

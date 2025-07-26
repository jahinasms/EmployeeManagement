using MimeKit;
using System.Net;
using System.Net.Mail;
using MailKit.Net.Smtp;
using SmtpClient = System.Net.Mail.SmtpClient;

namespace EmployeeManagement.DTO
{
    public class EmailUtility
    {

        //public static bool SendEmailViaMailKit(string toEmail, string subject, string body)
        //{
        //    try
        //    {
        //        var message = new MimeMessage();
        //        message.From.Add(new MailboxAddress("Your Name", "your-email@gmail.com"));
        //        message.To.Add(MailboxAddress.Parse(toEmail));
        //        message.Subject = subject;

        //        var bodyBuilder = new BodyBuilder
        //        {
        //            HtmlBody = body
        //        };
        //        message.Body = bodyBuilder.ToMessageBody();

        //        using (var client = new SmtpClient())
        //        {
        //            client.Connect("smtp.gmail.com", 587, MailKit.Security.SecureSocketOptions.StartTls);
        //            client.Authenticate("your-email@gmail.com", "your-app-password");

        //            client.Send(message);
        //            client.Disconnect(true);
        //        }

        //        return true;
        //    }
        //    catch (Exception ex)
        //    {
        //        Console.WriteLine("❌ MailKit Error: " + ex.Message);
        //        return false;
        //    }
        //}

        //public static bool SendEmail(string toEmail, string subject, string body)
        //{
        //    try
        //    {
        //        Console.WriteLine("Step 1: Preparing MailMessage");

        //        var message = new MailMessage("your-email@gmail.com", toEmail, subject, body);
        //        message.IsBodyHtml = true;

        //        Console.WriteLine("Step 2: Creating SmtpClient");

        //        var smtp = new SmtpClient("smtp.gmail.com", 587)
        //        {
        //            Credentials = new NetworkCredential("your-email@gmail.com", "your-app-password"),
        //            EnableSsl = true
        //        };

        //        Console.WriteLine("Step 3: Sending Email");

        //        smtp.Send(message);  // <-- agar yahan nahi pahuch raha, pehle error ho raha

        //        Console.WriteLine("Step 4: Email Sent Successfully");
        //        return true;
        //    }
        //    catch (Exception ex)
        //    {
        //        Console.WriteLine("❌ Email Send Error: " + ex.Message);
        //        return false;
        //    }
        //}


    }
}

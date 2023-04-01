using AafridahFolio.Models;
using MailBee.ImapMail;
using MailBee.SmtpMail;
using Microsoft.AspNetCore.Mvc;
using SendGrid.Helpers.Mail;
using System.Diagnostics;
using System.Net;
using System.Net.Mail;

namespace AafridahFolio.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
        public string SendMessage(Details details)
        {
            try
            {

                
                MailMessage Msg = new MailMessage();
                
                // Sender e-mail address.
                Msg.From = new MailAddress("aafridahmanzoor@gmail.com");
                // Recipient e-mail address.
                Msg.To.Add("nefeso8082@duiter.com");
                //Msg.CC.Add("zcd@gmail.com");
                Msg.Subject = "Timesheet Payment Instruction updated";
                Msg.IsBodyHtml = true;
                Msg.Body = details.Message.ToString();
                NetworkCredential loginInfo = new NetworkCredential(Convert.ToString("aafridahmanzoor@gmail.com"), Convert.ToString("9070573939me")); // password for connection smtp if u dont have have then pass blank

                SmtpClient smtp = new SmtpClient();
                smtp.UseDefaultCredentials = true;
                smtp.Credentials = loginInfo;
                smtp.EnableSsl = true;
                //No need for port
                smtp.Host = Convert.ToString("smtp.gmail.com");
                //smtp.Port = int.Parse(ConfigurationManager.AppSettings["PortNumber"]);
                smtp.Send(Msg);
                //MailMessage newMail = new MailMessage();
                //// use the Gmail SMTP Host
                //SmtpClient client = new SmtpClient("smtp.gmail.com");

                //// Follow the RFS 5321 Email Standard
                //newMail.From = new MailAddress("aafridahmanzoor@gmail.com", details.Name);

                //newMail.To.Add("nefeso8082@duiter.com");// declare the email subject

                //newMail.Subject = "My First Email"; // use HTML for the email body

                //newMail.IsBodyHtml = true; newMail.Body = "<h1> This is my first Templated Email in C# </h1>";

                //// enable SSL for encryption across channels
                //client.EnableSsl = true;
                //// Port 465 for SSL communication
                //client.Port = 465;
                //// Provide authentication information with Gmail SMTP server to authenticate your sender account
                //client.Credentials = new System.Net.NetworkCredential("aafridahmanzoor@gmail.com", "9070573939me");

                //client.Send(newMail); // Send the constructed mail
                //Console.WriteLine("Email Sent");


                //using (MailMessage mail = new MailMessage())
                //{
                //    mail.From = new MailAddress("aafridahmanzoor@gmail.com");
                //    mail.To.Add("nefeso8082@duiter.com");
                //    mail.Subject = details.Subject + "From: " + details.Name + $"({details.Email})";
                //    mail.Body = details.Message;
                //    mail.IsBodyHtml = true;
                //    //mail.Attachments.Add(new Attachment("C:\\file.zip"));

                //    using (SmtpClient smtp = new SmtpClient("smtp.gmail.com", 587))
                //    {
                //        smtp.Credentials = new NetworkCredential("aafridahmanzoor@gmail.com", "9070573939me");
                //        smtp.EnableSsl = true;
                //        smtp.Send(mail);
                //    }
                //}
                //MailBee.ImapMail.Imap imapComponent = new Imap("MN120-5A92921992AA921D9241B9F0B3A4-8E96");
                //MailMessage message = new MailMessage();
                //SmtpClient smtp = new SmtpClient();
                //message.From = new MailAddress("");
                //message.To.Add(new MailAddress(""));
                //message.Subject = details.Subject+ "From: "+ details.Name + $"({details.Email})";
                //message.IsBodyHtml = false; //to make message body as html
                //message.Body = details.Message;
                //smtp.Port = 587;
                //smtp.Host = "smtp.gmail.com"; //for gmail host
                //smtp.EnableSsl = true;
                //smtp.UseDefaultCredentials = false;
                //smtp.Credentials = new System.Net.NetworkCredential("aafridahmanzoor@gmail.com", "9070573939me");
                ////smtp.DeliveryMethod = SmtpDeliveryMethod.Network;
                //smtp.Send(message);
                //Smtp.QuickSend(details.Email, "aafridahmanzoor@gmail.com", details.Subject, details.Message);
                return "sent";
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error -" + ex);
            }
            return "notsent";
            //return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using PahadiDukan.Service.interfaces;
using System.Net;
using System.Net.Mail;
using System.Text;

namespace TheLvyLeagueEdge.Controllers
{
    public class ContactUsController : Controller
    {
        private readonly string _email_template_path;
        private readonly string app_password;
        private readonly string email_id;
        private readonly IPDLogger _pdlogger;
        private string pathString;
        public ContactUsController(IConfiguration configuration, IPDLogger logger)
        {
            _pdlogger = logger;
            _email_template_path = configuration.GetSection("template:email_template").Value;
            app_password = configuration.GetSection("app_password").Value;
            email_id = configuration.GetSection("email_id").Value;
        }
        public IActionResult Index()
        {
             pathString = _pdlogger.CreateDirectory("Contact", "Bala");
            //ViewBag.succ = 1
            pathString = Path.Combine(pathString, "contactUS.txt");
            _pdlogger.LogError("InsideContactUS", pathString);
            return View();
        }
        
        [HttpPost]
        public IActionResult ContactToAdmin(IFormCollection form)
        {
            pathString = _pdlogger.CreateDirectory("Contact", "Bala");
            //ViewBag.succ = 1
            pathString = Path.Combine(pathString, "contactUS.txt");

            pathString = Path.Combine(pathString, "contactUS.txt");
            try
            {
                string fullname = form["fullname"];
                _pdlogger.LogError(fullname, pathString);
                string mobile = form["mobile"];
                _pdlogger.LogError(mobile, pathString);
                string email = form["email"];
                _pdlogger.LogError(email, pathString);
                var Resume = form.Files[0];
                _pdlogger.LogError(Resume.ToString(), pathString);
                string linkdinBio = form["linkdinBio"];
                _pdlogger.LogError(linkdinBio, pathString);
                string ug_cgpa = form["ug_cgpa"];
                string master_cgpa = form["master_cgpa"];
                string gmatScore = form["gmatScore"];
                string targetedSchool = form["targetedSchool"];
                string query = form["query"];

                var email_htmlText = System.IO.File.ReadAllText(_email_template_path);
                email_htmlText=email_htmlText.Replace("#fullname#", fullname);
                email_htmlText=email_htmlText.Replace("#mobile#",mobile);
                email_htmlText=email_htmlText.Replace("#email#",email);
                email_htmlText=email_htmlText.Replace("#ug_cgpa#",ug_cgpa);
                email_htmlText=email_htmlText.Replace("#linkdinBio#",linkdinBio);
                email_htmlText=email_htmlText.Replace("#master_cgpa#", !string.IsNullOrWhiteSpace(master_cgpa)? master_cgpa : "N/A");
                email_htmlText=email_htmlText.Replace("#gmatScore#", !string.IsNullOrWhiteSpace(gmatScore) ? gmatScore:"N/A");
                email_htmlText=email_htmlText.Replace("#targetedSchool#",targetedSchool);
                email_htmlText= email_htmlText.Replace("#query#",query);
                email_htmlText= email_htmlText.Replace("#gMAtScore#", !string.IsNullOrWhiteSpace(gmatScore)?",‌&nbsp;‌&nbsp;GMAT/GRE Score - " + gmatScore:"");
                var msg = new MailMessage();
                msg.From = new MailAddress("theivybala@gmail.com");
                msg.To.Add("theivybala@gmail.com");
                msg.Subject = fullname+ " Requested";
                msg.IsBodyHtml = true;
                msg.Body = email_htmlText;
                string fileName = Path.GetFileName(Resume.FileName);
                
                msg.Attachments.Add(new Attachment(Resume.OpenReadStream(), fileName));

                msg.Priority = MailPriority.High;
                var client = new SmtpClient("smtp.gmail.com", 587);
                var basicCredential1 = new NetworkCredential(email_id, app_password);
                client.EnableSsl = true;
                client.UseDefaultCredentials = false;
                client.Credentials = basicCredential1;

                client.Send(msg);
                ViewBag.Message = String.Format("Hello{0}.\\ncurrent Date and time:{1}", fullname, DateTime.Now.ToString());
            }
            catch (Exception ex)
            {
                _pdlogger.LogError(ex.Message, pathString);
                throw ex;
            }

            //return RedirectToAction("thank-you", "ContactUs");
            return Ok(1);
        }
    }
}

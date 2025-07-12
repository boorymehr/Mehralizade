using Microsoft.AspNetCore.Mvc;
using System;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Xml.Linq;
using test.Ulity;

namespace test.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> MessageSend(string Email = "",string FullName = "",string Title = "",string Text = "")
        {
            if (Email != "" && FullName != "" && Title != "" && Text != "")
            {
                var EmailValid = "@gmail.com";
                if (!Email.Contains(EmailValid) && (!Title.StartsWith("09") || !Title.StartsWith("+98")))
                {
                    TempData["Err"] = "لطفا فرم را یه درستی وارد کنید";
                    return Redirect("/");
                }
                else
                {
                    test.Ulity.Ulity Sms = new test.Ulity.Ulity();
                    var TextSms = $"شماره:{Title} + ایمیل:{Email} + نام:{FullName}";
                    var res = Sms.IsSend(TextSms, Text, Email);
                }
            }
            TempData["Succ"] = "ارسال شد";
            return Redirect("/");
        }
        public IActionResult ResomeDownload()
        {
            var file = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "pdf", "1.pdf");
            var stream = new FileStream(file, FileMode.Open);
            return File(stream, "application/pdf", "FileDownloadName.pdf");
        }
    }
}

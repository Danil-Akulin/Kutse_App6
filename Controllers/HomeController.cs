using Kutse_App.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Helpers;
using System.Web.Mvc;

namespace Kutse_App.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index() //открывает страницу индекс
        {
            string[] peod = new string[12] {"pidu1", "pidu2","pidu3","pidu4","pidu5","pidu6","pidu7","pidu8","pidu9","pidu10","pidu11","pidu12"};
            /*string pidu = "";
            if (DateTime.Now.Month==1)
            {
                pidu = "Jaanuari pidu";
            }*/
            ViewBag.Message = "Ootan sind oma peole!" +peod[DateTime.Now.Month-1]+ " Palun tule kindlasti!";
            int hour = DateTime.Now.Hour;
            ViewBag.Greeting = hour < 12 ? "Tere hommikust!" : "Tere päeva";
            ViewBag.Greeting = hour > 12 ? "Tere õhtul!" : "Tere päeva";
            //ViewBag.Message
            //ViewData 
            return View();
        }
        [HttpGet]
        public ViewResult Ankeet()
        {
            return View();
        }
        [HttpPost]
        public ViewResult Ankeet(Guest guest)
        {
            E_mail(guest);
            if (ModelState.IsValid)
            {
                db.Guests.Add(guest);
                db.SaveChanges();
                return View("Thanks", guest);
            }
            else
            {
                return View();
            }
        }
        public void E_mail(Guest guest)
        {
            try
            {
                WebMail.SmtpServer = "smtp.gmail.com";
                WebMail.SmtpPort = 587;
                WebMail.EnableSsl = true;
                WebMail.UserName = "programmeeriminetthk2@gmail.com";
                WebMail.Password = "2.kuursus tarpv20";
                WebMail.From = "programmerimine@gmail.com";
                WebMail.Send("programmeeriminetthk2@gmail.com", "Vastus kutsele", guest.Name + " vastas " + ((guest.WillAttend ?? false) ?
                    "tuleb poole " : "ei tule poole"));
                    ViewBag.Message = "Kiri on saatnud!";
            }
            catch (Exception)
            {

                ViewBag.Message = "Mul on kahju!Ei saa kitja saada!!!";
            }
        }
        public ActionResult About() //открывает страницу about
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";
            return View();
        }

        GuestContext db = new GuestContext();
        public ActionResult Guests()
        {
            IEnumerable<Guest> guests = db.Guests;
            return View(guests);
        }
    }
}
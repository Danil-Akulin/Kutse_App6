using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Data.Entity;
using System.Web.Mvc;

namespace Kutse_App.Models
{
    public class Guest
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "On vaja sisesta oma nime!!!")]
        public string Name { get; set; }
        [Required(ErrorMessage ="On vaja sisestada email!!!")]
        [RegularExpression(@".+\@.+\..+", ErrorMessage ="Viga emaili sisestamiseks!!!")]
        public string Email { get; set; }
        [Required(ErrorMessage ="Sisesta onma number")]
        [RegularExpression(@"\+372.+", ErrorMessage ="Vale telefoni number, Alguses on +372....")]
        public string Phone { get; set; }
        [Required(ErrorMessage = "Tee oma valik!!!")]
        public bool? WillAttend { get; set; }

        /*GuestContext db = new GuestContext();
        [Authorize]
        public ActionResult Guests()
        {
            IEnumerable<Guest> guests = db.Guests;
            return View(guests);
        }*/
    }

}
using System.Data.Entity;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;

namespace Kutse_App.Models
{
    public class GuestContext : DbContext
    {
        public DbSet<Guest> Guests { get; set; }
    }
}
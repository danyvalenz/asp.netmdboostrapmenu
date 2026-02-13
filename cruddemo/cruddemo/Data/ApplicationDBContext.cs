using cruddemo.Models;
using Microsoft.EntityFrameworkCore;
namespace cruddemo.Data
{
    public class ApplicationDBContext  : DbContext
    {
        public ApplicationDBContext(DbContextOptions<ApplicationDBContext> opt) :base(opt){ }


        //DBSet

        public DbSet<Contacto> Contactos { get; set; }
        public DbSet<MenuLateral> MenusLaterales { get; set; }

    }
}

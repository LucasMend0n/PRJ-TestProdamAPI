using CafeteriaCrud.Models;
using Microsoft.EntityFrameworkCore;
using System.Security.Cryptography.X509Certificates;

namespace CafeteriaCrud.Db
{
    public class AppDbContext : DbContext

    {
        public DbSet<Client> Clients { get; set; }
        public DbSet<Product> Products { get; set; }    

        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) 
        {

        }
    }
}

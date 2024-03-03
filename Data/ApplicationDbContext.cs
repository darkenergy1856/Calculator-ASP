using Calculator.Models.Entities;
using Microsoft.EntityFrameworkCore;

namespace Calculator.Data
{
    public class ApplicationDbContext : DbContext

    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { 
       
        }

        public DbSet<Calculation> Calculations { get; set; }

    }
   

}

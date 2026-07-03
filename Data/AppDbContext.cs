using Microsoft.EntityFrameworkCore;
using PaymentManagementAPI.Models;
// includes thuis DbContex DbSet<> DbContextOptions<>
using Microsoft.EntityFrameworkCore;


namespace PaymentManagementAPI.Data
{
    public class AppDbContext : DbContext // Our application's database manager is AppDbContext, and it inherits all the database functionality from Entity Framework's DbContext.
    {
        // Who creates AppDbContext? ASP.NET Core. same like repo and services 
        public AppDbContext(DbContextOptions <AppDbContext> options)
            :base(options)
        {

        }

        public DbSet<Payment> Payments { get; set; }     // "Dear Entity Framework, my database has a table called Payments, and each row in that table is represented by the Payment class."
    }
}

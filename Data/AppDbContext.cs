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

        public DbSet<User> Users { get; set; }

        public DbSet<Payment> Payments { get; set; }     // "Dear Entity Framework, my database has a table called Payments, and each row in that table is represented by the Payment class."


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Payment>()
                .HasOne(p => p.Sender)
                .WithMany(u => u.SentPayments)
                .HasForeignKey(p => p.SenderId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Payment>()
                .HasOne(p => p.Receiver)
                .WithMany(u => u.ReceivedPayments)
                .HasForeignKey(p => p.ReceiverId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}

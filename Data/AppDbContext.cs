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

            modelBuilder.Entity<Payment>() // Configure the Payment table
                .HasOne(p => p.Sender)    // Each Payment has one Sender (User)
                .WithMany(u => u.SentPayments) // One User can have many sent Payments          
                .HasForeignKey(p => p.SenderId)  // // SenderId is the foreign key

                .OnDelete(DeleteBehavior.Restrict); // // Don't allow deleting the User if related Payments exist

            // One Payment has one Sender (User), one User can send many Payments, SenderId is the foreign key, and deleting a User is restricted if they have sent payments.
            modelBuilder.Entity<Payment>()
                .HasOne(p => p.Receiver)
                .WithMany(u => u.ReceivedPayments)
                .HasForeignKey(p => p.ReceiverId)
                .OnDelete(DeleteBehavior.Restrict);

            // 
        }
    }
}

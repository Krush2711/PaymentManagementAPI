
using Microsoft.EntityFrameworkCore;
using PaymentManagementAPI.Data;
using PaymentManagementAPI.Interfaces;
using PaymentManagementAPI.Middelware;
using PaymentManagementAPI.Repositories;
using PaymentManagementAPI.Repositories.UserRepository;
//using PaymentManagementAPI.Repositories;
using PaymentManagementAPI.Services;
using System.Runtime.CompilerServices;



namespace PaymentManagementAPI
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddControllers(); // adding receppptionist
            builder.Services.AddDbContext<AppDbContext>(options =>
            {
                options.UseSqlServer(
                    builder.Configuration.GetConnectionString("DefaultConnection"));
            }); // storing the food / data base 


            builder.Services.AddScoped<IUserRepository, UserRepository>(); // this the services -> used by controler -> create the services object 
            builder.Services.AddScoped<IUserService, UserService>(); // Controller = Waiter , Service = Chef

            builder.Services.AddScoped<IPaymentService, PaymentService>();//  "Dear ASP.NET Core, whenever anyone asks for an IPaymentService, create a PaymentService object and give it to them."
            builder.Services.AddScoped<IPaymentRepository, PaymentRepository>(); // "Dear ASP.NET Core, whenever anyone asks for an IPaymentRepository, create a PaymentRepository object and give it to them."
            //// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            var app = builder.Build(); // application is ready we can build it 

            // Configure the HTTP request pipeline.
            if(app.Environment.IsDevelopment())
{
                app.UseSwagger();
                app.UseSwaggerUI(); // 
            }

            app.UseHttpsRedirection(); // redirection of the 
            app.UseMiddleware<ExceptionMiddleware>();
            app.UseAuthorization(); // 


            app.MapControllers();

            app.Run();
        }
    }
}

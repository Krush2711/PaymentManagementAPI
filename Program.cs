
using PaymentManagementAPI.Interfaces;
using PaymentManagementAPI.Repositories;
using PaymentManagementAPI.Services;

namespace PaymentManagementAPI
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddControllers();
            
            builder.Services.AddScoped<IPaymentService, PaymentService>();//  "Dear ASP.NET Core, whenever anyone asks for an IPaymentService, create a PaymentService object and give it to them."
            builder.Services.AddScoped<IPaymentRepository, PaymentRepository>(); // "Dear ASP.NET Core, whenever anyone asks for an IPaymentRepository, create a PaymentRepository object and give it to them."
            // Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if(app.Environment.IsDevelopment())
{
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}

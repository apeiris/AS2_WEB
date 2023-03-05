using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using AS2_WEB.Data;
namespace AS2_WEB
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
            builder.Services.AddDbContext<AS2_WEBContext>(options =>
                options.UseSqlServer(builder.Configuration.GetConnectionString("AS2_WEBContext") ?? throw new InvalidOperationException("Connection string 'AS2_WEBContext' not found.")));

            // Add services to the container.
            builder.Services.AddRazorPages();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.MapRazorPages();

            app.Run();
        }
    }
}
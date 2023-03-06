using AS2_WEB.Data;
using Microsoft.EntityFrameworkCore;
namespace AS2_WEB
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
            builder.Services.AddDbContext<AS2DBContext>(options =>
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
            app.Use(async (context, next) =>
            {
                if (context.Request.Path == "/")
                {
                    context.Response.Redirect("/Index");
                    return;
                }
                await next();
            });


            app.Run();
        }
    }
}
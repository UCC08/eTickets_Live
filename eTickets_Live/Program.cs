using eTickets_Live.Data;
using Microsoft.EntityFrameworkCore;

internal class Program
{
    private static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        // Add services to the container.
        builder.Services.AddControllersWithViews(); // Controllerların View ları olması gerektiğini bildiriyor.

        // AppDBContext tanımlarımın enjecte edilmesi (Depenceny Injection - DI) (GetConnectionStrings - appsettings.json dan okuyor)

        builder.Services.AddDbContext<AppDbContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("Conn")));

        var app = builder.Build();

        // Configure the HTTP request pipeline.
        if (!app.Environment.IsDevelopment())
        {
            app.UseExceptionHandler("/Home/Error");
            // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
            app.UseHsts();
        }

        app.UseHttpsRedirection();
        app.UseStaticFiles();

        app.UseRouting();

        app.UseAuthorization();

        app.MapControllerRoute(
            name: "default",
            pattern: "{controller=Movies}/{action=Index}/{id?}");

        // Program çalışmadan önce hazırlanmış olan test datasının VT ye gönderilmesi
        AppDBInitializer.Seed(app);

        app.Run();
    }
}
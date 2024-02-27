using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using RentApp.DataAccessLayer;
using RentApp.Repository;


namespace RentApp.BussinesLayer.Configuration
{
    public class Configuration
    {
        //private WebApplicationBuilder builder;

        //public Configuration(WebApplicationBuilder builder)
        //{
        //    this.builder = builder;
        //}

        //public WebApplication Configure()
        //{
        //    builder.Services.AddControllersWithViews();
        //    builder.Services.AddHttpContextAccessor();
        //    //builder.Services.AddSingleton<IActionContextAccessor, ActionContextAccessor>();
        //    builder.Services.AddDbContext<ApplicationContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));
        //    builder.Services.AddDataProtection();
        //    #region Repositories
        //    builder.Services.AddTransient(typeof(IGenericRepository<>), typeof(GenericRepository<>));
        //    #endregion

        //    #region Helpers
        //    //builder.Services.AddScoped<SendEmail>();
        //    #endregion

        //    //builder.Services.AddScoped<LoginBL>();

        //    builder.Services.AddDistributedMemoryCache();

        //    builder.Services.AddSession(options =>
        //    {
        //        options.IdleTimeout = TimeSpan.FromSeconds(10);
        //        options.Cookie.HttpOnly = true;
        //        options.Cookie.IsEssential = true;
        //    });
        //    var app = builder.Build();
        //    return app;
        //}

        //public void Service(WebApplication app)
        //{
        //    try
        //    {
        //        if (!app.Environment.IsDevelopment())
        //        {
        //            app.UseExceptionHandler("/Home/Error");
        //            // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
        //            app.UseHsts();
        //        }

        //        app.UseHttpsRedirection();
        //        app.UseStaticFiles();

        //        app.UseRouting();

        //        app.UseAuthorization();

        //        app.MapControllerRoute(
        //            name: "default",
        //            pattern: "{controller=Login}/{action=Index}/{id?}");


        //        app.MapAreaControllerRoute(
        //             name: "areas",
        //             areaName: "areas",
        //              pattern: "{area:exists}/{controller=Home}/{action=Index}/{id?}");

        //        app.UseSession();
        //        app.Run();
        //    }
        //    catch (Exception ex)
        //    {

        //    }
        //}
    }
}

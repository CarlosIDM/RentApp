using Microsoft.EntityFrameworkCore;
using RentApp.BussinesLayer.Helpers;
using RentApp.BussinesLayer.Login;
using RentApp.DataAccessLayer;
using RentApp.Repository;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
string connectionStrings = builder.Configuration.GetConnectionString("DefaultConnection");
builder.Services.AddDbContext<ApplicationContext>(options => options.UseSqlServer(connectionStrings));
#if DEBUG
builder.Services.AddSassCompiler();
#endif

#region Repositories
builder.Services.AddTransient(typeof(IGenericRepository<>), typeof(GenericRepository<>));
#endregion

#region Class
builder.Services.AddTransient<LoginBL>();
builder.Services.AddTransient<IAuthenticationTokens, AuthenticationTokens>();
builder.Services.AddTransient<IRulesValidations, RulesValidations>();
#endregion

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
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.MapAreaControllerRoute(
                     name: "myareasadministrator",
                     areaName: "Administrator",
                      pattern: "{area:exists}/{controller=Index}/{action=Index}/{id?}");
app.MapAreaControllerRoute(
					 name: "myareasuser",
					 areaName: "User",
					  pattern: "{area:exists}/{controller=Index}/{action=Index}/{id?}");

app.Run();

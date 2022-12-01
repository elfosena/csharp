using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.FileProviders;
using ShopApp.Business.Abstract;
using ShopApp.Business.Concrete;
using ShopApp.DataAccess.Abstract;
using ShopApp.DataAccess.Concrete.EfCore;
using ShopApp.WebUI.EmailService;
using ShopApp.WebUI.Identity;
using Microsoft.AspNetCore.Identity.UI.Services;


public class Program
{
    private static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        // Add services to the container.
        builder.Services.AddRazorPages();
        builder.Services.AddMvcCore();
        builder.Services.AddScoped < IProductDal, EfCoreProductDal >();
        builder.Services.AddScoped<IProductService, ProductManager>();
        builder.Services.AddScoped<ICategoryDal, EfCoreCategoryDal>();
        builder.Services.AddScoped<ICategoryService, CategoryManager>();
        builder.Services.AddControllersWithViews();
        builder.Services.AddDbContext<ApplicationIdentityDbContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("IdentityConnection")));
        builder.Services.AddIdentity<ApplicationUser, IdentityRole>()
            .AddEntityFrameworkStores<ApplicationIdentityDbContext>()
            .AddDefaultTokenProviders();

        builder.Services.AddTransient<IEmailSender, EmailSender>();

        builder.Services.Configure<IdentityOptions>(options =>
        {
            options.Password.RequireDigit = true;
            options.Password.RequireLowercase = true;
            options.Password.RequiredLength = 6;
            options.Password.RequireNonAlphanumeric = true;
            options.Password.RequireUppercase = true;

            options.Lockout.MaxFailedAccessAttempts = 5;
            options.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromMinutes(5);
            options.Lockout.AllowedForNewUsers = true;

            // options.User.AllowedUserNameCharacters = "";
            options.User.RequireUniqueEmail = true;

            options.SignIn.RequireConfirmedEmail = true;
            options.SignIn.RequireConfirmedPhoneNumber = false;
        });

        builder.Services.ConfigureApplicationCookie(options =>
        {
            options.LoginPath = "/account/login";
            options.LogoutPath = "/account/logout";
            options.AccessDeniedPath = "/account/accessdenied";
            options.ExpireTimeSpan = TimeSpan.FromMinutes(60);
            options.SlidingExpiration = true;
            options.Cookie = new CookieBuilder
            {
                HttpOnly = true,
                Name = ".ShopApp.Security.Cookie",
                SameSite = SameSiteMode.Strict
            };

        });

        var app = builder.Build();

        // Configure the HTTP request pipeline.
        if (!app.Environment.IsDevelopment())
        {
            app.UseExceptionHandler("/Error");
        }
        SeedDatabase.Seed();
        // SeedIdentity.Seed().Wait; ????

        app.UseHttpsRedirection();
        app.UseStaticFiles();

        app.UseRouting();

        app.MapControllerRoute(
            name: "default",
            pattern: "{controller=Home}/{action=Index}/{id?}");

        app.MapControllerRoute(
            name: "products",
            pattern: "products/{category?}",
            defaults: new {controller = "Shop", action="List" }
            );

        app.MapControllerRoute(
            name: "adminProducts",
            pattern: "admin/products",
            defaults: new { controller = "Admin", action = "ProductList" }
            );

        app.MapControllerRoute(
            name: "adminProducts",
            pattern: "admin/products/{id?}",
            defaults: new { controller = "Admin", action = "EditProduct" }
            );


        app.UseAuthorization();
        app.UseAuthentication();
        app.MapControllers();
        app.MapRazorPages();
        app.Run();
    }
}
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.FileProviders;
using ShopApp.Business.Abstract;
using ShopApp.Business.Concrete;
using ShopApp.DataAccess.Abstract;
using ShopApp.DataAccess.Concrete.EfCore;

internal class Program
{
    private static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        // Add services to the container.
        builder.Services.AddRazorPages();
        builder.Services.AddScoped < IProductDal, EfCoreProductDal >();
        builder.Services.AddScoped<IProductService, ProductManager>();
        builder.Services.AddScoped<ICategoryDal, EfCoreCategoryDal>();
        builder.Services.AddScoped<ICategoryService, CategoryManager>();
        builder.Services.AddControllersWithViews();
        // builder.Services.AddMvc().SetCompatibilityVersion(version: Microsoft.AspNetCore.Mvc.CompatibilityVersion);
        var app = builder.Build();

        // Configure the HTTP request pipeline.
        if (!app.Environment.IsDevelopment())
        {
            app.UseExceptionHandler("/Error");
        }
        SeedDatabase.Seed();

        app.UseHttpsRedirection();
        app.UseStaticFiles();

        app.UseRouting();
        app.UseAuthorization();
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



        app.MapControllers();
        app.MapRazorPages();
        app.Run();
    }
}
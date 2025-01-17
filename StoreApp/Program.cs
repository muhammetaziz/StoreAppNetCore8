using Microsoft.EntityFrameworkCore;
using StoreApp.Data.Abstract;
using StoreApp.Data.Concrete;
using StoreApp.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddRazorPages();
builder.Services.AddAutoMapper(typeof(MapperProfile).Assembly);

builder.Services.AddDbContext<StoreDbContext>(options =>
{
    options.UseSqlServer(builder.Configuration["ConnectionStrings:StoreDbConnection"], b => b.MigrationsAssembly("StoreApp"));
});

builder.Services.AddScoped<IStoreRepository, EFStoreRepository>();
builder.Services.AddScoped<IOrderRepository, EfOrderRepository>();

builder.Services.AddDistributedMemoryCache();
builder.Services.AddSession();
builder.Services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
builder.Services.AddScoped<CartsModel>(sc=>SessionCart.GetCarts(sc));

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
app.UseSession();
app.UseRouting();

app.UseAuthorization();



//kategori urun listesi product/category
app.MapControllerRoute(
    name: "Contact",
    pattern: "contact",
    defaults: new { controller = "AboutContact", action = "Contact" }
);

app.MapControllerRoute(
    name: "About",
    pattern: "about",
    defaults: new { controller = "AboutContact", action = "About" }
);
app.MapControllerRoute(
    name: "Checkout",
    pattern: "checkout",
    defaults: new { controller = "Order", action = "Checkout" }
);
app.MapControllerRoute("products_in_category", "products/{category?}", new { controller = "Home", action = "Index" });
//urundetay product/s24
app.MapControllerRoute("product_details", "{name}", new { controller = "Home", action = "Details" });

app.MapDefaultControllerRoute();
app.MapRazorPages();
app.Run();

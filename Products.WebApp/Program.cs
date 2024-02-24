using Products.BL;
using Products.BL.Abstractions;
using Products.BL.Implementations;
using Products.Infrastructure.Configs;
using Products.Infrastructure.Repositories;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.Configure<ProductStoreDatabase>(builder.Configuration.GetSection("ProductStoreDatabase"));
builder.Services.AddSingleton<IProductRepository, ProductRepository>();
builder.Services.AddTransient<IProductService, ProductService>();

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

app.MapControllerRoute(
    name: "api",
    pattern: "api/{controller}/{action}/{id?}");

app.Run();
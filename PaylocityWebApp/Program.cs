using Paylocity.DAL;
using Paylocity.DAL.Interfaces;
using Paylocity.Services;
using Paylocity.Services.Interfaces;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllersWithViews();

// Register Libraries
// Get Connection String from configuration
builder.Services.AddScoped((sp) => new PaylocityContext("Data Source=(localdb)\\local; Initial Catalog=Paylocity;Persist Security Info=True;Trusted_Connection=True;Application Name = Paylocity_Web;Connection Timeout=60; Integrated Security=true;"));

// Register Repositories

builder.Services.AddScoped<IEmployeeRepository, EmployeeRepository>();


// Register Services
builder.Services.AddScoped<IBenefitService>(sp => new BenefitService(0.1,500,1000));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseRouting();


app.MapControllerRoute(
    name: "default",
    pattern: "{controller}/{action=Index}/{id?}");

app.MapFallbackToFile("index.html"); ;

app.Run();

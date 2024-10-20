using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using motors.Areas.Identity.Data;
using motors.Data;
var builder = WebApplication.CreateBuilder(args);
var connectionString = builder.Configuration.GetConnectionString("motorsContextConnection") ?? throw new InvalidOperationException("Connection string 'motorsContextConnection' not found.");

builder.Services.AddDbContext<motorsContext>(options => options.UseSqlServer(connectionString));

builder.Services.AddDefaultIdentity<motorsUser>(options => options.SignIn.RequireConfirmedAccount = false).AddEntityFrameworkStores<motorsContext>();

// Add services to the container.
builder.Services.AddControllersWithViews();
//Подлкючение поддержки razor pages
builder.Services.AddRazorPages();
//Настройка паролей 
builder.Services.Configure<IdentityOptions>(options =>
{
    options.Password.RequireUppercase = false;
    options.Password.RequiredLength = 3;
    options.Password.RequiredUniqueChars = 0;
});

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
;

//Подлкючение поддержки razor pages
app.MapRazorPages();

app.Run();

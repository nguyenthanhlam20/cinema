
using Cinema.Models;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.EntityFrameworkCore;


var builder = WebApplication.CreateBuilder(args);
// Add services to the container.
builder.Services.AddDistributedMemoryCache(); // Use a distributed cache for session data


//Regist DbContext Service
builder.Services.AddDbContext<CinemaContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("DB"));

    // Configure logging to None (no logging)
    options.UseLoggerFactory(LoggerFactory.Create(builder => builder.AddFilter((category, level) => level == LogLevel.None)));
});
builder.Services.AddSession();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddControllersWithViews();
builder.Services.AddAuthentication((options =>
{
    options.DefaultAuthenticateScheme = CookieAuthenticationDefaults.AuthenticationScheme;
    options.DefaultChallengeScheme = CookieAuthenticationDefaults.AuthenticationScheme;
}))
.AddCookie(options =>
{
    options.LoginPath = "/Authen/SignIn";
    options.ExpireTimeSpan = TimeSpan.FromMinutes(60);
    options.SlidingExpiration = true;
    options.AccessDeniedPath = "/Error/Error403";
});


builder.Services.AddHttpContextAccessor();

//builder.Services.AddScoped<PublicPageFilter>();

// Transient

builder.Services.AddMemoryCache();
builder.Services.AddHttpClient();


var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{

    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseExceptionHandler("/Error");
//app.UseStatusCodePagesWithRedirects("/Error/Error404");

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseSession();
app.UseRouting();

// Configure middleware
//app.UseMiddleware<SessionExpirationMiddleware>();

app.UseAuthentication();
app.UseAuthorization();

// Configure role-based routing
app.UseEndpoints(endpoints =>
{
    endpoints.MapControllerRoute(
       name: "Admin",
       pattern: "{area:exists}/{controller=Home}/{action=Index}/{id?}"
   );

    endpoints.MapControllerRoute(
       name: "User",
       pattern: "{area:exists}/{controller=Home}/{action=Index}/{id?}"
   );

    endpoints.MapControllerRoute(
        name: "default",
        pattern: "{controller=Home}/{action=Index}/{id?}"
        );
});

app.Run();
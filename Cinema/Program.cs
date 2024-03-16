
using Cinema.Models;
using Cinema.Services.Authens;
using Cinema.Services.Bookings;
using Cinema.Services.Countries;
using Cinema.Services.Films;
using Cinema.Services.Genres;
using Cinema.Services.Rooms;
using Cinema.Services.Seats;
using Cinema.Services.Shows;
using Cinema.Services.Slots;
using Cinema.Services.Users;
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
    options.LoginPath = "/Authen/Login";
    options.ExpireTimeSpan = TimeSpan.FromMinutes(60);
    options.SlidingExpiration = true;
    options.AccessDeniedPath = "/Error/Error403";
});


builder.Services.AddHttpContextAccessor();

// Transient
builder.Services.AddTransient<IAuthenService, AuthenService>();
builder.Services.AddTransient<IBookingService, BookingService>();
builder.Services.AddTransient<ICountryService, CountryService>();
builder.Services.AddTransient<IFilmService, FilmService>();
builder.Services.AddTransient<IGenreService, GenreService>();
builder.Services.AddTransient<IRoomService, RoomService>();
builder.Services.AddTransient<ISeatService, SeatService>();
builder.Services.AddTransient<IShowService, ShowService>();
builder.Services.AddTransient<ISlotService, SlotService>();
builder.Services.AddTransient<IUserService, UserService>();

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
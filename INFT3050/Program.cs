using Microsoft.EntityFrameworkCore;
using INFT3050.Models;
using Microsoft.AspNetCore.Identity;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

//for cookies and session state
builder.Services.AddMemoryCache();
builder.Services.AddSession();

builder.Services.AddControllersWithViews();

//Dependency Injection.
builder.Services.AddDbContext<VitaStoreContext>(options =>
                options.UseSqlServer(builder.Configuration.GetConnectionString("VitaStoreContext")));

//for authentication and authorization
builder.Services.AddIdentity<User, IdentityRole>(options => {
    options.Password.RequiredLength = 8;
    options.Password.RequireNonAlphanumeric = false;
    options.Password.RequireUppercase = true;
    options.Password.RequireLowercase = true;
    options.Password.RequireDigit = true;

    //lockout settings
    options.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromMinutes(3);
    options.Lockout.MaxFailedAccessAttempts = 3;
    options.Lockout.AllowedForNewUsers = true;
}).AddEntityFrameworkStores<VitaStoreContext>()
  .AddDefaultTokenProviders();

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

//for session state
app.UseSession();

//for authentication and authorization
app.UseAuthentication();
app.UseAuthorization();

//seed data for idemntity user
var scopeFactory = app.Services.GetRequiredService<IServiceScopeFactory>();
using (var scope = scopeFactory.CreateScope())
{
    await ConfigureIdentity.CreateAdminUserAsync(scope.ServiceProvider);
}


app.MapAreaControllerRoute(
    name: "employee",
    areaName: "Employee",
    pattern: "Employee/{controller=Employee}/{action=Index}/{id?}");

app.MapAreaControllerRoute(
    name: "admin",
    areaName: "Admin",
    pattern: "Admin/{controller=Admin}/{action=Index}/{id?}");

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");





app.Run();

//map controller for admin area example 
/*
 * app.MapAreaControllerRoute(
   name: "admin",
   areaName: "Admin",
   pattern: "Admin/{controller=Book}/{action=Index}/{id?}");
   
Components of the Code
app.MapAreaControllerRoute:

This method is used to define a route specifically for an area in an ASP.NET Core application.
It maps a route to a set of controllers that belong to the specified area.
name: "admin":

This is the name of the route. Naming routes can be useful for generating URLs or for referring to the route in other parts of your application.
In this case, the route is named "admin".
areaName: "Admin":

This specifies the name of the area to which this route applies.
The area is a way to logically group controllers and views in your application. Here, it refers to the "Admin" area.
pattern: "Admin/{controller=Book}/{action=Index}/{id?}":

This is the URL pattern for the route.
The pattern specifies that URLs that start with "Admin" will be handled by this route.
{controller=Book}: This part of the pattern indicates that if no specific controller is provided in the URL, it will default to the Book controller.
{action=Index}: This part of the pattern indicates that if no specific action is provided in the URL, it will default to the Index action.
{id?}: This part of the pattern indicates that the id parameter is optional (? means optional). This parameter can be used to pass an ID to the action method.
     
*/



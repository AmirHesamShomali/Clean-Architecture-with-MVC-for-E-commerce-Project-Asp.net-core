using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Internal;
using MyEshop_Application.Interfaces.Contexts;
using MyEshop_Application.Interfaces.IFacedPattern;
using MyEshop_Application.Services.Carts.Command;
using MyEshop_Application.Services.Carts.Queries;
using MyEshop_Application.Services.Comments.Commands;
using MyEshop_Application.Services.Comments.Queries;
using MyEshop_Application.Services.GetMenutem.Queries;
using MyEshop_Application.Services.Products.FacedPattern;
using MyEshop_Application.Services.Users.Commands.DeleteUsers;
using MyEshop_Application.Services.Users.Commands.EditUser;
using MyEshop_Application.Services.Users.Commands.RegisterUser;
using MyEshop_Application.Services.Users.Queries.GetListUsers;
using MyEshop_Application.Services.Users.Queries.GetRoles;
using MyEshop_Persistence;
using Services.Carts.Command;
using Services.Users.Commands.LoginUser;
using static Services.Carts.Command.AddCart;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddScoped<IEditUserService,EditUserService>();
builder.Services.AddScoped<IGetUserServices,UserServices>();
builder.Services.AddScoped<ILoginUserService, LoginUserService>();
builder.Services.AddScoped<IRegisterUserService, RegisterUserService>();
builder.Services.AddScoped<IDeleteUserService, DeleteUserService>();
builder.Services.AddScoped<IGetListComments,GetListComments>();
builder.Services.AddScoped<IDeleteComment,DeleteComment>();
builder.Services.AddScoped<IAddCart, AddCart>();
builder.Services.AddScoped<IAddComment,AddComment>();
builder.Services.AddScoped<IGetListCarts, GetListCarts>();
builder.Services.AddScoped<IRemoveCart, RemoveCart>();
builder.Services.AddScoped<IProductFacad, ProductFacad>();
builder.Services.AddScoped<IGetMenuItem,GetMenuItem>();
builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme).AddCookie(option =>
{
    option.LoginPath = "/Acount/Login";
    option.LogoutPath = "/Acount/logout";
    option.ExpireTimeSpan = TimeSpan.FromDays(5);
});

builder.Services.AddScoped<IDatabaseContext, DatabaseContext>();
builder.Services.AddAuthorization(options =>
{
    options.AddPolicy("AdminOnly", policy => policy.RequireClaim("IsAdmin", "True"));
});
builder.Services.AddDbContext<DatabaseContext>(option =>
{
    option.UseSqlServer("Data Source=.;Initial Catalog=My_EshopCore_DB;TrustServerCertificate=True;Integrated security=true");
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
app.UseAuthentication();
app.UseAuthorization();
app.UseEndpoints(endpoints =>
{
    endpoints.MapControllerRoute(
      name: "areas",
      pattern: "{area:exists}/{controller=Home}/{action=Index}/{id?}"
    );
});


app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();

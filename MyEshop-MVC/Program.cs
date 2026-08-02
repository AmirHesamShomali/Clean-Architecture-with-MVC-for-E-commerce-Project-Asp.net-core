using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Internal;
using MyEshop_Application.Interfaces.Contexts;
using MyEshop_Application.Services.Users.Commands.RegisterUser;
using MyEshop_Application.Services.Users.Queries.GetListUsers;
using MyEshop_Application.Services.Users.Queries.GetRoles;
using MyEshop_Persistence;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddScoped<IGetUserServices,UserServices>();
builder.Services.AddScoped<IRegisterUserService, RegisterUserService>();
builder.Services.AddScoped<IGetRoleService, GetRoleService>();


builder.Services.AddScoped<IDatabaseContext, DatabaseContext>();
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

using DataAccess.Contexts;
using Microsoft.EntityFrameworkCore;
using Business;
using Business.Services;

var builder = WebApplication.CreateBuilder(args);


builder.Services.AddDbContext<Db>(options => options.UseSqlServer("server=(localdb)\\mssqllocaldb;database=StDB;trusted_connection=true;"));

builder.Services.AddScoped<IGradeService, GradeService>();
builder.Services.AddScoped<IStudentService, StudentService>();

builder.Services.AddControllersWithViews();

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

app.Run();
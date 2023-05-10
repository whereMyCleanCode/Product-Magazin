using EfLesson.DAL;
using Microsoft.AspNetCore;
using Npgsql;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddScoped<EfLesson.BL.IIdentityProduct, EfLesson.BL.IdentityProduct>();

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddDbContext<ProductDb>();
builder.Services.AddMvc();
builder.Services.AddRazorPages();

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


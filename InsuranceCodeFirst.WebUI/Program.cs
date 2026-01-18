using InsuranceCodeFirst.Business.Extensions;
using InsuranceCodeFirst.DAL.Extensions;
using InsuranceCodeFirst.WebUI.Middleware;
using Microsoft.ML;
using Serilog;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
Log.Logger = new LoggerConfiguration()
    .ReadFrom.Configuration(builder.Configuration)
    .CreateLogger();

builder.Host.UseSerilog();


builder.Services.AddControllersWithViews();

builder.Services.AddRepositoriesExt(builder.Configuration)
                .AddServiceExt();

builder.Services.AddScoped<MLContext>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Admin/AdminDashboard/Error");
}
else
{
    app.UseExceptionHandler("/Admin/AdminDashboard/Error");
    app.UseHsts();
}

app.UseMiddleware<GlobalExceptionMiddleware>();

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
  name: "areas",
  pattern: "{area:exists}/{controller=Home}/{action=Index}/{id?}"
);

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();

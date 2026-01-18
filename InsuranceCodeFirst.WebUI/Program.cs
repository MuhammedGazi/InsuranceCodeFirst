using InsuranceCodeFirst.Business.Extensions;
using InsuranceCodeFirst.DAL.Extensions;
using InsuranceCodeFirst.WebUI.Middleware;
using Microsoft.ML;
using Serilog;
using Serilog.Debugging;
using Serilog.Exceptions;
using Serilog.Sinks.Elasticsearch;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddAllElasticApm();

Log.Logger = new LoggerConfiguration()
    .ReadFrom.Configuration(builder.Configuration)
    .CreateLogger();
configureLogging();
builder.Host.UseSerilog();
SelfLog.Enable(msg => Console.Error.WriteLine(msg));


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

void configureLogging()
{
    var environment = Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT");

    // Config dosyasýný okuma
    var configuration = new ConfigurationBuilder()
        .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
        .AddJsonFile($"appsettings.{environment}.json", optional: true)
        .Build();

    Log.Logger = new LoggerConfiguration()
        .Enrich.FromLogContext()
        .Enrich.WithExceptionDetails() // Serilog.Exceptions paketi lazým
        .WriteTo.Debug()
        .WriteTo.Console()
        .WriteTo.Elasticsearch(ConfigureElasticSink(configuration, environment))
        .Enrich.WithProperty("Environment", environment)
        .ReadFrom.Configuration(configuration)
        .CreateLogger();
}

ElasticsearchSinkOptions ConfigureElasticSink(IConfigurationRoot configuration, string environment)
{
    var envName = string.IsNullOrEmpty(environment) ? "production" : environment;
    return new ElasticsearchSinkOptions(new Uri(configuration["ElasticConfiguration:Uri"]))
    {
        TypeName = null,
        AutoRegisterTemplateVersion = AutoRegisterTemplateVersion.ESv6,
        AutoRegisterTemplate = true,
        // Replace ile noktalarý tireye çevir ve her þeyi küçült
        IndexFormat = $"{Assembly.GetExecutingAssembly().GetName().Name.ToLower().Replace('.', '-')}-{envName.ToLower()}-{DateTime.UtcNow:yyyy-MM}",
        // Hata durumunda log klasörüne dosya atsýn (Debug için)
        FailureCallback = e => Console.WriteLine("ES Error: " + e.MessageTemplate),
        EmitEventFailure = EmitEventFailureHandling.WriteToSelfLog |
                           EmitEventFailureHandling.WriteToFailureSink |
                           EmitEventFailureHandling.RaiseCallback
    };
}
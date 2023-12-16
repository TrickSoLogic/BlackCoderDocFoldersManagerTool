using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Hosting;
using BlackCoderDocFoldersManagerTool.Data;
using System.Globalization;

CultureInfo.DefaultThreadCurrentCulture = CultureInfo.DefaultThreadCurrentUICulture = IndianDateExtensionMethods.GetEnglishCulture();

var builder = WebApplication.CreateBuilder(args);

// Configuration for SQL Server
builder.Services.AddDbContext<DemoDMSContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DemoDMSContext")
    ?? throw new InvalidOperationException("Connection string 'DemoDMSContext' not found.")));

builder.Services.AddPortableObjectLocalization();

builder.Services.Configure<RequestLocalizationOptions>(options => options
    .AddSupportedCultures("fa")
    .AddSupportedUICultures("fa"));

builder.Services.AddMvc().AddViewLocalization();

// Add services to the container.
builder.Services.AddControllersWithViews();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseRouting();
app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.UseRequestLocalization();
app.MapRazorPages();

app.Run();

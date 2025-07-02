using CountriesDataApp.Clients;
using CountriesDataApp.Clients;
using CountriesDataApp.Data;
using CountriesDataApp.Repositories;
using CountriesDataApp.Services;
using CountriesDataApp.Services.Analysis;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.SqlServer;
using System.Net.Http.Headers;

var builder = WebApplication.CreateBuilder(args);

// Register analysis service
builder.Services.AddScoped<ICountryAnalysisService, CountryAnalysisService>();



// Register analyzers
builder.Services.AddScoped<ICountryAnalyzer, RegionCountAnalyzer>();
builder.Services.AddScoped<ICountryAnalyzer, PopulationAnalyzer>();






// DbContext registration
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

// Repository & Service

builder.Services.AddScoped<ICountryRepository, CountryRepository>();
builder.Services.AddScoped<ICountryService, CountryService>();


// Add services to the container.
builder.Services.AddControllersWithViews();


// Register CountryClient as a typed client:
builder.Services.AddHttpClient<ICountryClient, CountryClient>(client =>
{
    client.BaseAddress = new Uri("https://restcountries.com/");
    client.DefaultRequestHeaders.Accept.Clear();
    client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
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

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();

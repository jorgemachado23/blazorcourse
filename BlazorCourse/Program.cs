using BlazorCourse.Components;
using BlazorCourse.Contracts.Repositories;
using BlazorCourse.Contracts.Services;
using BlazorCourse.Data;
using BlazorCourse.Repositories;
using BlazorCourse.Services;
using BlazorCourse.State;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents();

builder.Services.AddDbContextFactory<AppDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddScoped<ICountryDataService, CountryDataService>();
builder.Services.AddScoped<IJobCategoryDataService, JobCategoryDataService>();
builder.Services.AddScoped<IEmployeeRepository, EmployeeRepository>();
builder.Services.AddScoped<IEmployeeDataService, EmployeeDataService>();
builder.Services.AddScoped<ApplicationState>();
builder.Services.AddScoped<ITimeRegistrationRepository, TimeRegistrationRepository>();
builder.Services.AddScoped<ITimeRegistrationDataService, TimeRegistrationDataService>();
builder.Services.AddScoped<ICountryRepository, CountryRepository>();
builder.Services.AddScoped<IJobCategoryRepository, JobCategoryRepository>();
builder.Services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error", createScopeForErrors: true);
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();


app.UseAntiforgery();

app.MapStaticAssets();
app.MapRazorComponents<App>()
    .AddInteractiveServerRenderMode();

await app.RunAsync();

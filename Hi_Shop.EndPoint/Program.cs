using Hi_Shop.Application.Interfaces.Contexts;
using Hi_Shop.Application.Visitors.SaveVisitorInfo;
using Hi_Shop.Application.Visitors.VisitorOnline;
using Hi_Shop.EndPoint.Hubs;
using Hi_Shop.EndPoint.Utilities.Filters;
using Hi_Shop.EndPoint.Utilities.Filters.Middlewares;
using Hi_Shop.Infrastructure.IdentityConfigs;
using Hi_Shop.Persistence.Contexts;
using Hi_Shop.Persistence.Contexts.MongoContext;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();


#region Connection String
var provider =builder.Services.BuildServiceProvider();
var configuration=provider.GetRequiredService<IConfiguration>();
string connection = configuration["ConnectionString:SqlServer"];
builder.Services.AddDbContext<DataBaseContext>(option => option.UseSqlServer(connection));
builder.Services.AddIdentityService(configuration);
builder.Services.AddAuthorization();
builder.Services.ConfigureApplicationCookie(option =>
{
    option.ExpireTimeSpan = TimeSpan.FromMinutes(10);
    option.LoginPath = "/account/login";
    option.AccessDeniedPath = "/Account/AccessDenied";
    option.SlidingExpiration = true;
});
#endregion

builder.Services.AddTransient(typeof(IMongoDbContext<>), typeof(MongoDbContext<>));
builder.Services.AddTransient<ISaveVisitorInfoService, SaveVisitorInfoService>();
builder.Services.AddTransient<IVisitorOnlineService, VisitorOnlineService>();
builder.Services.AddScoped<SaveVisitorFilter>();
builder.Services.AddSignalR();


var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}
app.UseSetVisitorId();
app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();
app.UseAuthentication();
app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");
app.MapHub<OnlineVisitorHub>("/chathub");
app.Run();

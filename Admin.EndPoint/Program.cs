using Admin.EndPoint.MappingProfiles;
using Application.Catalogs.CatalogTypes;
using Hi_Shop.Application.Interfaces.Contexts;
using Hi_Shop.Application.Visitors.GetTodayReport;
using Hi_Shop.Infrastructure.MappingProfile;
using Hi_Shop.Persistence.Contexts;
using Hi_Shop.Persistence.Contexts.MongoContext;
using Hi_Shop.Persistence.Seeds;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();
builder.Services.AddScoped<IGetTodayReportService, GetTodayReportService>();
builder.Services.AddScoped<IDataBaseContext, DataBaseContext>();
builder.Services.AddTransient<ICatalogTypeService, CatalogTypeService>();
builder.Services.AddTransient(typeof(IMongoDbContext<>), typeof(MongoDbContext<>));
builder.Services.AddScoped<DataBaseContextSeed>();



#region ConnectionString
var provider = builder.Services.BuildServiceProvider();
var configuration = provider.GetRequiredService<IConfiguration>();
string connection = configuration["ConnectionString:SqlServer"];
builder.Services.AddDbContext<DataBaseContext>(option => option.UseSqlServer(connection));
#endregion


#region Mapper
builder.Services.AddAutoMapper(typeof(CatalogMappingProfile));
builder.Services.AddAutoMapper(typeof(CatalogVMMappingProfile));
#endregion

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapRazorPages();

app.Run();

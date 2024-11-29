using AutoMapper;
using Crow.Data.Context;
using Crow.Data.Repository;
using Crow.Models;
using Crow.Services;
using Crow.ViewModels;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

#region Conectando Banco de dados

var connectionString = builder.Configuration.GetConnectionString("DatabaseString");

builder.Services.AddDbContext<DatabaseContext>(
    opt => opt.UseMySql(connectionString, new MySqlServerVersion(new Version(9, 0, 1)))
    );

#endregion

#region Registro IServiceColletion

builder.Services.AddScoped<IClienteRepository, ClienteRepository>();
builder.Services.AddScoped<IClienteService, ClienteService>();

#endregion

#region AutoMapper

var mapperConfig = new AutoMapper.MapperConfiguration(m =>
{
    m.AllowNullCollections = true;
    m.AllowNullDestinationValues = true;

    m.CreateMap<ClienteModel, ClienteCreateViewModel>();
    m.CreateMap<ClienteCreateViewModel, ClienteModel>();
});

IMapper mapper = mapperConfig.CreateMapper();

builder.Services.AddSingleton(mapper);
#endregion

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

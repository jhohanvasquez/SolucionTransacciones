using Microsoft.EntityFrameworkCore;
using System;
using AppTransacciones.Repository.Implementacion;
using AppTransacciones.Repository.Contratos;
using AppTransacciones.Utilidades;
using AppTransacciones.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddMemoryCache();

builder.Services.AddSingleton<DBTransaccionesContext>();

builder.Services.AddSingleton<APITransaccionesContext>();

builder.Services.AddControllersWithViews();

builder.Services.AddAutoMapper(typeof(AutoMapperProfile));

builder.Services.AddScoped<IUsuarioRepositorio, UsuarioRepositorio>();
builder.Services.AddScoped<IRolRepositorio, RolRepositorio>();
builder.Services.AddScoped<IDashBoardRepositorio, DashBoardRepositorio>();
builder.Services.AddScoped<IZonaVirtualRepositorio, ZonaVirtualRepositorio>();
builder.Services.AddScoped<IComercioRepositorio, ComercioRepositorio>();
builder.Services.AddScoped<ITransaccionRepositorio, TransaccionRepositorio>();


var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
}

app.UseStaticFiles();
app.UseRouting();


app.MapControllerRoute(
    name: "default",
    pattern: "{controller}/{action=Index}/{id?}");

app.MapFallbackToFile("index.html"); ;

app.Run();

using doe_mais_ads.Context;
using doe_mais_ads.Data;
using doe_mais_ads.Service;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();
builder.Services.AddServerSideBlazor();
builder.Services.AddSingleton<WeatherForecastService>();

// Injeção de dependências
builder.Services.AddScoped<EntidadeService>();
builder.Services.AddScoped<CampanhaService>();
builder.Services.AddScoped<DoacoesService>();
builder.Services.AddScoped<ItemService>();

string mySqlConnectionStr = builder.Configuration.GetConnectionString("DefaultConnection")!;

builder.Services.AddDbContextPool<ContextoBD>(options =>
    options.UseMySql(mySqlConnectionStr, ServerVersion.AutoDetect(mySqlConnectionStr))
);

var app = builder.Build();

// Configure the HTTP request pipeline.
// if (!app.Environment.IsDevelopment())
// {
//     app.UseExceptionHandler("/Error");
//     // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
//     app.UseHsts();
// }

// app.UseHttpsRedirection();

app.UseStaticFiles();

app.UseRouting();

app.MapBlazorHub();
app.MapFallbackToPage("/_Host");

app.Run();

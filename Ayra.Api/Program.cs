using Ayra.Application.Services;
using Ayra.Infrastructure.Context;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseOracle(builder.Configuration.GetConnectionString("DefaultConnection")));

//Adicionando RazorPages
builder.Services.AddRazorPages();
//Adicionando os servicos a serem utilizados
builder.Services.AddScoped<CoordinateService>();
builder.Services.AddScoped<EmergencyContactService>();
builder.Services.AddScoped<UserService>();
builder.Services.AddScoped<EmergencyUserService>();
builder.Services.AddScoped<MapMarkerService>();
builder.Services.AddScoped<AlertService>();
builder.Services.AddScoped<SafeRouteService>();
builder.Services.AddScoped<SafeLocationService>();
builder.Services.AddScoped<SafeTipService>();

var app = builder.Build();
// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

// Configura o pipeline HTTP
app.UseStaticFiles(); // Permite servir arquivos estáticos (CSS, JS, etc.)
app.MapRazorPages();  // Mapeia as Razor Pages

app.Run();

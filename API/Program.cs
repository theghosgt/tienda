using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder();

// Add services to the container.

builder.Services.AddControllers();

var configuration = builder.Build();
var serverVersion = new MySqlServerVersion(new Version(8,0,31));
var app = builder.Build();

builder.Services.AddDbContext<TiendaContext>(options =>
{
    options.UseMySql(builder.Configuration.GetConnectionString("DefaultConnection"),
        serverVersion);
});
// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
  
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();

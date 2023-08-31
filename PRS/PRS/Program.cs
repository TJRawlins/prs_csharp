using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using PRS.Data;
var builder = WebApplication.CreateBuilder(args);
builder.Services.AddDbContext<PRSContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DevDb") ?? throw new InvalidOperationException("Connection string 'DevDb' not found.")));

// Add services to the container.
builder.Services.AddCors();

builder.Services.AddControllers();

var app = builder.Build();

// Configure the HTTP request pipeline.
app.UseCors(x => x.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod());

app.UseAuthorization();

app.MapControllers();

app.Run();

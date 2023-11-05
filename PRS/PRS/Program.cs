using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using PRS.Data;

var connStrKey = "ProdDb";
#if DEBUG
    connStrKey = "DevDb";
#endif

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddDbContext<PRSContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString(connStrKey) ?? throw new InvalidOperationException("Connection string 'ProdDb' not found.")));

// Add services to the container.
builder.Services.AddCors();

builder.Services.AddControllers();

var app = builder.Build();

// Configure the HTTP request pipeline. Allows or disallows Angular to talk to server
app.UseCors(x => x.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod());

app.UseAuthorization();

app.MapControllers();

app.Run();

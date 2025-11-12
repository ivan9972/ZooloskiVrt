using Microsoft.EntityFrameworkCore;
using ZooloskiVrt.Data;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();

// Registracija konteksta EF-a
builder.Services.AddDbContext<ZooloskiVrtContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("ZooloskiVrtCS")));

var app = builder.Build();

// Configure the HTTP request pipeline.
app.MapControllers();

app.Run();

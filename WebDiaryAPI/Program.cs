using Microsoft.EntityFrameworkCore;
using WebDiaryAPI.Data;

// WebApplication is a class that provides a way to configure and run a web application.
var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();
// tilføjer connectionString fra appsettings.json til IoC containeren
builder.Services.AddDbContext<ApplicationDbContext>(
    options => options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddOpenApi();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Configure the HTTP request pipeline.
var app = builder.Build();

// If the environment is development, the OpenAPI specification is generated and Swagger UI is enabled.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();

// Run the application.
app.Run();


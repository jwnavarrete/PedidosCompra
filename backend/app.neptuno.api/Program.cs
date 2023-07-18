using app.neptuno.data;
using app.neptuno.api;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
    {
        c.SwaggerDoc("v1", new OpenApiInfo { Title = "API", Version = "v1" });

        // Configuración para incluir las propiedades de lista en Swagger
        // c.SchemaFilter<ListPropertySchemaFilter>();
    });
builder.Services.AddDbContext<DataContext>();
builder.Services.AddCors(options => options.AddPolicy(name: "DiresOrigins",
    policy =>
    {
        // policy.WithOrigins("http://localhost:7139").AllowAnyMethod().AllowAnyHeader();
        policy.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader();
    }));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors("DiresOrigins");

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();

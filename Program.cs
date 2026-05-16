using Microsoft.EntityFrameworkCore;
using Api1.Data;
using Api1;
using Scalar.AspNetCore;
using FluentValidation;
using Api1.Validations;
using System.Text.Json.Serialization;

var builder = WebApplication.CreateBuilder(args);
var config = builder.Configuration;

// Add services to the container.

builder.Services.AddServices(config);

builder.Services.AddControllers()
    .AddJsonOptions(options =>
    {
        options.JsonSerializerOptions.ReferenceHandler = System.Text.Json.Serialization.ReferenceHandler.IgnoreCycles;
    });

builder.Services.AddValidatorsFromAssemblyContaining<RegisterDtoValidation>();
var app = builder.Build();
app.MapScalarApiReference();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}



app.UseStaticFiles();
app.MapControllers();
app.MapGet("/", () => "Hello World!");

app.Run();

using ApiPrimerExamen.data;
using ApiPrimerExamen.Repositories;
using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Scalar.AspNetCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();

string connectionString = builder.Configuration.GetConnectionString("SqlAzure");
builder.Services.AddTransient<RepositoryPersonajes>();
builder.Services.AddDbContext<SeriesContext>
    (options => options.UseSqlServer(connectionString));
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();


var app = builder.Build();

// Configure the HTTP request pipeline.
//if (app.Environment.IsDevelopment())
//{
//}
    app.MapOpenApi();

app.UseHttpsRedirection();
//app.UseSwaggerUI(options =>
//{
//    options.SwaggerEndpoint("/openapi/v1.json", "Api Departamentos Routes");
//    options.RoutePrefix = "";
//});
app.MapScalarApiReference();

app.UseAuthorization();

app.MapControllers();

app.Run();

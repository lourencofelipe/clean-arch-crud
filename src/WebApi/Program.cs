using CleanArch.Persistence.Context;
using Microsoft.EntityFrameworkCore;
using Presentation.DI;
using Application.DI;
using Persistence.DI;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddApplication()
				.AddPersistence()
				.AddPresentation();

builder.Services.AddDbContext<EfContext>(options =>
	   options.UseInMemoryDatabase("InMemoryDatabase"));

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

app.Run();

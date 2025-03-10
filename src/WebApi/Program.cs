using Microsoft.AspNetCore.Authentication.JwtBearer;
using Swashbuckle.AspNetCore.Filters;
using Microsoft.IdentityModel.Tokens;
using CleanArch.Persistence.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using Application.DI;
using Persistence.DI;
using System.Text;

var builder = WebApplication.CreateBuilder(args);

var tokenKey = builder.Configuration.GetValue<string>("AppSettings:Token");

if (string.IsNullOrEmpty(tokenKey))
	throw new InvalidOperationException("JWT token not present");

var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(tokenKey));

builder.Services.AddControllers();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(options =>
{
	options.AddSecurityDefinition("oauth2", new OpenApiSecurityScheme
	{
		Description = "Standard Authorization header using the Bearer scheme (\"bearer {token}\")",
		In = ParameterLocation.Header,
		Name = "Authorization",
		Type = SecuritySchemeType.ApiKey
	});

	options.OperationFilter<SecurityRequirementsOperationFilter>();
});
builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
	.AddJwtBearer(options =>
	{
		options.TokenValidationParameters = new TokenValidationParameters
		{
			ValidateIssuerSigningKey = true,
			IssuerSigningKey = key,
			ValidateIssuer = false,
			ValidateAudience = false
		};
	});
builder.Services.AddCors(options => options.AddPolicy(name: "AllowAll",
	policy =>
	{
		 policy.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader();
	}));


builder.Services.AddApplication()
				.AddPersistence();

builder.Services.AddDbContext<EfContext>(options =>
	   options.UseInMemoryDatabase("InMemoryDatabase"));

var app = builder.Build();

// Configure the HTTP request pipeline.
app.UseSwagger();
app.UseSwaggerUI();

app.UseHttpsRedirection();

app.UseCors("NgOrigins");

app.UseAuthentication();

app.UseAuthorization();

app.MapControllers();

app.Run();

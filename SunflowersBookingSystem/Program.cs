using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Microsoft.OpenApi.Models;
using SunflowersBookingSystem.Data;
using SunflowersBookingSystem.Data.Models;
using SunflowersBookingSystem.Services.Helpers;
using SunflowersBookingSystem.Services.Mapping;
using SunflowersBookingSystem.Services.Users;
using SunflowersBookingSystem.Services.Users.Interfaces;
using SunflowersBookingSystem.Web.Helpers;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddDbContext<SunflowersDbContext>();
builder.Services.AddDatabaseDeveloperPageExceptionFilter();

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddSwaggerGen(c => {
	c.SwaggerDoc("v1", new OpenApiInfo
	{
		Title = "JWTToken_Auth_API",
		Version = "v1"
	});
	c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme()
	{
		Name = "Authorization",
		Type = SecuritySchemeType.ApiKey,
		Scheme = "Bearer",
		BearerFormat = "JWT",
		In = ParameterLocation.Header,
		Description = "JWT Authorization header using the Bearer scheme. \r\n\r\n Enter 'Bearer' [space] and then your token in the text input below.\r\n\r\nExample: \"Bearer 1safsfsdfdfd\"",
	});
	c.AddSecurityRequirement(new OpenApiSecurityRequirement {
		{
			new OpenApiSecurityScheme {
				Reference = new OpenApiReference {
					Type = ReferenceType.SecurityScheme,
						Id = "Bearer"
				}
			},
			new string[] {}
		}
	});
});

builder.Services.AddAutoMapper(typeof(Program));
builder.Services.AddScoped<IJwtUtils, JwtUtils>();
builder.Services.Configure<AppSettings>(builder.Configuration.GetSection("AppSettings"));

builder.Services.AddScoped<IUserService, UserService>();
builder.Services.AddSingleton(ConfigureMapperService());

static IMapper ConfigureMapperService()
{
	var mapperServiceConfigureation = new MapperConfiguration(cfg => {
		cfg.AddProfile<AutoMapperProfile>();
	});

	mapperServiceConfigureation.AssertConfigurationIsValid();

	return mapperServiceConfigureation.CreateMapper();
}


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
	app.UseSwagger();
	app.UseSwaggerUI();

	// global error handler
	app.UseMiddleware<ErrorHandlerMiddleware>();

	// custom jwt auth middleware
	app.UseMiddleware<JwtMiddleware>();

	app.MapControllers();
}
app.MapControllers();

app.UseHttpsRedirection();

app.UseAuthorization();

app.Run();

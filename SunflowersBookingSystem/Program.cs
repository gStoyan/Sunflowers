using AutoMapper;
using Microsoft.OpenApi.Models;
using Serilog;
using SunflowersBookingSystem.Data;
using SunflowersBookingSystem.Services.Helpers;
using SunflowersBookingSystem.Services.Mapping;
using SunflowersBookingSystem.Services.Users;
using SunflowersBookingSystem.Services.Users.Interfaces;
using SunflowersBookingSystem.Web.Helpers;
using Serilog.Events;
using Newtonsoft.Json.Serialization;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using Microsoft.Net.Http.Headers;
using Microsoft.AspNetCore.Authentication.JwtBearer;

var builder = WebApplication.CreateBuilder(args); 
// Configure Logger
var logger = new LoggerConfiguration()
   .ReadFrom.Configuration(builder.Configuration)
   .MinimumLevel.Debug()
   .MinimumLevel.Override("Microsoft", LogEventLevel.Information)
   .MinimumLevel.Override("Microsoft.AspNetCore", LogEventLevel.Warning)
   .MinimumLevel.Override("Microsoft.EntityFrameworkCore.Database.Command", LogEventLevel.Warning)
   //.WriteTo.File(new CompactJsonFormatter(), "log.txt")
   .CreateLogger();
builder.Logging.AddSerilog(logger);

// Add services to the container.
builder.Services.AddRazorPages();
builder.Services.AddMvc(options => options.EnableEndpointRouting = false)
	.AddNewtonsoftJson(o => o.SerializerSettings.ContractResolver = new DefaultContractResolver());

builder.Services.AddDbContext<SunflowersDbContext>();
builder.Services.AddDatabaseDeveloperPageExceptionFilter();

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddSwaggerGen(c => {
	c.SwaggerDoc("v1", new OpenApiInfo
	{
		Title = "JWTToken_Auth_API"
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

	app.MapControllers();
}

// global error handler
app.UseMiddleware<ErrorHandlerMiddleware>();

// custom jwt auth middleware
app.UseMiddleware<JwtMiddleware>();

app.MapRazorPages();
app.UseStaticFiles();
app.UseAuthentication();
app.UseAuthorization();
app.UseHttpsRedirection();
app.UseMvc(routes =>
{
	// need route and attribute on controller: [Area("Blogs")]
	routes.MapRoute(name: "mvcAreaRoute",
					template: "{area:exists}/{controller=Home}/{action=Index}");

	// default route for non-areas
	routes.MapRoute(
		name: "default",
		template: "{controller=Home}/{action=Index}/{id?}");
});

app.Logger.LogInformation(MyLogEvents.TestItem, "Starting the application.");
app.Run();
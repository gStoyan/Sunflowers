using Microsoft.AspNetCore.Identity;
using SunflowersBookingSystem.Data;
using SunflowersBookingSystem.Data.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddDbContext<SunflowersDbContext>();
builder.Services.AddDatabaseDeveloperPageExceptionFilter();


builder.Services.AddIdentity<User, IdentityRole<int>>(options =>
{
    options.User.RequireUniqueEmail = false;
})
    .AddEntityFrameworkStores<SunflowersDbContext>();
builder.Services.AddAuthentication();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.MapControllers();

app.UseHttpsRedirection();

app.UseAuthorization();


app.Run();

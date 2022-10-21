using Microsoft.AspNetCore.SignalR;
using Meddelandecentral.Models;
using Meddelandecentral.Services;
using Meddelandecentral.Hubs;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
var services = builder.Services;

services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
services.AddEndpointsApiExplorer();
services.AddSwaggerGen();
services.AddSignalR();
services.AddCors(opt => 
{
    opt.AddPolicy("ClientPermission", policy =>
    {
        policy.AllowAnyHeader()
            .AllowAnyMethod()
            .WithOrigins("https://localhost:3000")
            .AllowCredentials();
    });
});
services.AddDbContext<AppDbContext>(options =>
options.UseSqlite("DataSource=Database\\app.db"));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors("ClientPermission");

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.MapControllerRoute(
    name:"default",
    pattern:"{controller=Home}/action={Index}/{id?}");

app.MapHub<ChatHub>("/hubs/chat");

app.Run();


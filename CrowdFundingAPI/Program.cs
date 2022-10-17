using BLL.Interface;
using BLL.Services;
using DAL.Interface;
using DAL.Repositories;
<<<<<<< HEAD

=======
using System.Text.Json;
>>>>>>> 87d9a2e5c386c7487f03754b2869b3d470d937c1

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

<<<<<<< HEAD
builder.Services.AddScoped<IProjectRepo, ProjectRepo>();
builder.Services.AddScoped<IProjectService, ProjectService>();
=======
builder.Services.AddScoped<IUserService, UserRepo>();
builder.Services.AddScoped<IUserRoleService, UserRoleRepo>();

builder.Services.AddScoped<ILocalUserService, LocalUserService>();


>>>>>>> 87d9a2e5c386c7487f03754b2869b3d470d937c1

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

using CSV_api.Data;
using CSV_api.Services.Implementations;
using CSV_api.Services.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Configuration;
using AutoMapper;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddScoped<IUserService, UserService>();
builder.Services.AddScoped<IProjectService, ProjectService>();
builder.Services.AddTransient<ICommentService, CommentService>();
builder.Services.AddTransient<ITaskService, TaskService>();
builder.Services.AddDbContext<TestDbContext>(options =>
                options.UseSqlServer("Data Source=UAIR18;Initial Catalog=TestDB;Integrated Security=True;Trust Server Certificate=True"));
builder.Services.AddMemoryCache();
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

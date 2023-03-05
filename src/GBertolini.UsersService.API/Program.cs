using AutoMapper;
using GBertolini.UsersService.API.Extensions;
using GBertolini.UsersService.API.Filters;
using GBertolini.UsersService.Models.AutoMapperProfiles;
using Microsoft.AspNetCore.Mvc;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddSingleton(MapperConfig.InitializeAutoMapper().CreateMapper());

// Adding custom filter
builder.Services.AddValidateInputModelFilter();

//Adding custom services
builder.Services.AddUsersServices();


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

// Using custom middleware
app.UseInterceptorErrorHandlingMiddleware();

app.MapControllers();

app.Run();

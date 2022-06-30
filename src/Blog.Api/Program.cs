using System.Net.Mime;
using Blog.Application.SignalR;
using Blog.Infra.CrossCutting.IoC;
using Blog.Services.Api.Configurations;
using Blog.Services.Api.SetupExtensions;
using MediatR;
using Microsoft.AspNetCore.Diagnostics;

var builder = WebApplication.CreateBuilder(args);

// ----- Database -----
builder.Services.AddCustomizedDatabase(builder.Configuration);

// ----- Auth -----
builder.Services.AddCustomizedAuth(builder.Configuration);

// ----- Auth -----
builder.Services.AddAutoMapperSetup();

// Adding MediatR for Domain Events and Notifications
builder.Services.AddMediatR(typeof(Program).Assembly);

builder.Services.AddCustomizedHash(builder.Configuration);

builder.Services.AddSignalR();

// .NET Native DI Abstraction
builder.Services.RegisterServices();

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddCustomizedSwagger(builder.Environment);

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseCustomizedSwagger();
}
app.UseExceptionHandler("/error");

app.UseHttpsRedirection();
app.UseStaticFiles();

// -----CORS---- 
app.UseCors("EnableCors");

// ----- Auth -----
app.UseCustomizedAuth();

app.MapHub<CommentHub>(nameof(CommentHub));
app.MapHub<UserManagerHub>(nameof(UserManagerHub));

app.MapControllers();

app.Run();

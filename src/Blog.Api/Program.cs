using Blog.Application.SignalR;
using Blog.Infra.CrossCutting.IoC;
using Blog.Services.Api.Configurations;
using Blog.Services.Api.SetupExtensions;
using MediatR;

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
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

// -----CORS---- 
app.UseCors(x => x
    .AllowAnyOrigin()
    .AllowAnyMethod()
    .AllowAnyHeader());

// ----- Auth -----
app.UseCustomizedAuth();

app.MapHub<CommentHub>(nameof(CommentHub));

app.MapControllers();

app.Run();

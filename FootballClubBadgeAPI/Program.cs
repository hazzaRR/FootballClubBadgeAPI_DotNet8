using Azure.Storage.Blobs;
using FootballClubBadgeAPI.Interfaces;
using FootballClubBadgeAPI.Services;
using Microsoft.Extensions.Configuration;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

string? connectionString = builder.Configuration["AzureStorage:ConnectionString"];

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


if (builder.Environment.IsDevelopment())
{
    builder.Services.AddScoped<IImageStorageService, LocalImageStorageService>();
}
else
{
    builder.Services.AddSingleton(x => new BlobServiceClient(connectionString));
    builder.Services.AddScoped<IImageStorageService, AzureImageStorageService>();
}


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

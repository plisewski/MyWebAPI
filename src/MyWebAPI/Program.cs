using Microsoft.Extensions.Options;
using MyWebAPI.Configuration;
using MyWebAPI.Services.Storage;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
var services = builder.Services;

// Configure storage options
services.ConfigureStorageOptions(builder.Configuration);

services.AddControllers();

// Register the storage service based on the selected option
services.AddTransient<IStorageService>(serviceProvider =>
{
    var storageOptions = serviceProvider.GetRequiredService<IOptions<StorageOptions>>().Value;

    if (storageOptions.SelectedStorage == "inmem")
    {
        return new InMemoryStorageService();
    }
    else if (storageOptions.SelectedStorage == "local")
    {
        return new LocalFileStorageService();
    }
    else if (storageOptions.SelectedStorage == "azureSQL")
    {
        return new AzureSqlStorageService();
    }
    // Default to InMemoryStorageService if the selected storage option is not recognized
    return new InMemoryStorageService();
});

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

app.UseAuthorization();

app.MapControllers();

app.Run();

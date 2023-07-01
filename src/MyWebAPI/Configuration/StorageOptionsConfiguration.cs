namespace MyWebAPI.Configuration;

public static class StorageOptionsConfiguration
{
    public static void ConfigureStorageOptions(this IServiceCollection services, IConfiguration configuration)
    {
        var storageOptions = new StorageOptions();
        configuration.GetSection("StorageOptions").Bind(storageOptions);

        services.AddSingleton(storageOptions);
    }
}

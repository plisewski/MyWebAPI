using MyWebAPI.Models;

namespace MyWebAPI.Services.Storage;

public class InMemoryStorageService : IStorageService
{
    private readonly List<Product> _products;

    public InMemoryStorageService()
    {
        // Initializing the product data in memory
        _products = new List<Product>
        {
            new Product { Id = 1, Name = "Product 1", Price = 1.99m },
            new Product { Id = 2, Name = "Product 2", Price = 19.99m },
            new Product { Id = 3, Name = "Product 3", Price = 199.99m },
            new Product { Id = 4, Name = "Product 4", Price = 1999.99m },
        };
    }

    public IEnumerable<Product> GetAllData()
    {
        return _products;
    }

    public Product GetDataById(int id)
    {
        return _products.FirstOrDefault(p => p.Id == id);
    }
}

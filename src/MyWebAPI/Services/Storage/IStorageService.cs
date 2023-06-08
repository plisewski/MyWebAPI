using MyWebAPI.Models;

namespace MyWebAPI.Services.Storage;

public interface IStorageService
{
    IEnumerable<Product> GetAllData();
    Product GetDataById(int id);
}

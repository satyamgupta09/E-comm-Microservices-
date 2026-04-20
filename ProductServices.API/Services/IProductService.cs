using ProductServices.API.Model;

namespace ProductServices.API.Services
{
    public class IProductService
    {
        public Task<List<Product>> GetAll();
        public Task<Product> GetById(int id);
        public Task<List<Product>> GetByIds(List<int> ids);
        public Task Add(Product product);
    }
}

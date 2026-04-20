using ProductServices.API.Model;

namespace ProductServices.API.Repositories
{
    public class IProductRepository
    {
        public Task<List<Product>> GetAll();
        public Task<Product> GetById(int id);
        public Task<List<Product>> GetByIds(List<int> ids);
        public Task Add(Product product);
    }
}

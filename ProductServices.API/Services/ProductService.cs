using ProductServices.API.Model;
using ProductServices.API.Repositories;

namespace ProductServices.API.Services
{
    public class ProductService
    {
        private readonly IProductRepository _repo;

        public ProductService(IProductRepository repo)
        {
            _repo = repo;
        }
        public async Task<List<Product>> GetAll()
        {
            return await _repo.GetAll();
        }

        public async Task<Product> GetById(int id)
        {
            if (id < 0)
            {
                throw new Exception("Id cannot be zero");
            }

            Product product = await _repo.GetById(id);

            if (product == null)
            {
                throw new Exception("Product not found");
            }

            return product;
        }

        public async Task<List<Product>> GetByIds(List<int> ids)
        {
            if (ids == null || !ids.Any())
            {
                throw new Exception("Ids List is empty");
            }

            return await _repo.GetByIds(ids);
        }

        public async Task Add(Product product)
        {
            if (product == null)
            {
                throw new Exception("Product details cannot be null");
            }

            if (product.Id <= 0 || product.Price < 0 || product.Name == null)
            {
                throw new Exception("Invalid Product properties");
            }

            await _repo.Add(product);
        }
    }
}

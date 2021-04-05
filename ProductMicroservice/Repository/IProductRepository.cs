using ProductMicroservice.Model;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ProductMicroservice.Repository
{
    public interface IProductRepository
    {
        Task<List<Product>> GetProduct();
        Task<Product> GetProductDetail(int id);
        Task<List<Product>> SearchProduct(string name);
        Task<bool> AddProduct(Product product);
        Task<bool> UpdateProduct(Product product);
        Task<bool> DeleteAllProduct();
        Task<bool> DeleteById(int id);
    }
}

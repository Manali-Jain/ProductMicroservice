using Microsoft.EntityFrameworkCore;
using ProductMicroservice.DBContexts;
using ProductMicroservice.Model;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProductMicroservice.Repository
{
    public class ProductRepository : IProductRepository
    {
        #region variable
        private readonly ProductContext _dbContext;
        #endregion

        #region constructor
        public ProductRepository(ProductContext productContext)
        {
            _dbContext = productContext;
        }
        #endregion


        #region method
        public async Task<List<Product>> GetProduct()
        {
            var data = await Task.Run(() => _dbContext.Products.ToList());
            return data;
        }

        public async Task<Product> GetProductDetail(int id)
        {
            var data = await Task.Run(() => _dbContext.Products.Find(id));
            return data;
        }

        public async Task<List<Product>> SearchProduct(string name)
        {
           
                var data = (from p in _dbContext.Products
                             where p.Name.Contains(name)
                             select p).ToList();
                return data;
        }

        public async Task<bool> AddProduct(Product product)
        {
            await Task.Run(() => _dbContext.Products.Add(product));
            int resp=_dbContext.SaveChanges();
            if (resp>0)
                return true;
            return false;
        }

        public async Task<bool> UpdateProduct(Product product)
        {
             _dbContext.Entry(product).State = EntityState.Modified;
            int resp = _dbContext.SaveChanges();
            if (resp > 0)
                return true;
            return false;
        }

        public async Task<bool> DeleteAllProduct()
        {
            foreach (var entity in _dbContext.Products)
            {
                await Task.Run(() => _dbContext.Products.Remove(entity));
            }
            int resp = _dbContext.SaveChanges();
            if (resp > 0)
                return true;
            return false;
        }

        public async Task<bool> DeleteById(int id)
        {
            var data = await Task.Run(() => _dbContext.Products.Find(id));
            await Task.Run(() => _dbContext.Products.Remove(data));
            int resp = _dbContext.SaveChanges();
            if (resp > 0)
                return true;
            return false;
        }
        #endregion
    }
}

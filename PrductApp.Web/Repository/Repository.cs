using ProductApp.Web.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProductApp.Web.Repository
{
    public class Repository<TEntity> : IRepository<TEntity> where TEntity : Product
    {
        private readonly IList<Product> _products;

        public Repository()
        {
            _products = new List<Product>() {
                new Product { Id = 1, Color = "Red", Name = "Pen", Price = 2.1M, Stock = 13 },
                new Product { Id = 2, Color = "Blue", Name = "Pencil", Price = 1M, Stock = 8 },
                new Product { Id = 3, Color = "Green", Name = "Scale", Price = 3.4M, Stock = 21 },
            };
        }

        public async Task Create(TEntity entity)
        {
            await Task.Delay(2);
            _products.Add(entity);
        }

        public void Delete(TEntity entity)
        {
            _products.Remove(entity);
        }

        public async Task<IEnumerable<TEntity>> GetAll()
        {
            await Task.Delay(2);
            return (IEnumerable<TEntity>)_products;
        }

        public async Task<TEntity> GetById(int id)
        {
            await Task.Delay(2);
            return (TEntity)_products.First(x => x.Id == id);
        }

        public void Update(TEntity entity)
        {
            var product = _products.First(x => x.Id == entity.Id);
            product.Name = entity.Name;
            product.Price = entity.Price;
            product.Stock = entity.Stock;
        }
    }
}

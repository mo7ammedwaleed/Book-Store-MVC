using System.Linq.Expressions;
using BookStore.DataAccess.Data;
using BookStore.DataAccess.Repository.IRepository;
using BookStore.Models;

namespace BookStore.DataAccess.Repository
{
    public class ProductRepository : Repository<Product>,IProductRepository
    {
        private readonly ApplicationDbContext _db;
        public ProductRepository(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }
        public void Update(Product obj)
        {
            var productFromDb = _db.Products.FirstOrDefault(s => s.Id == obj.Id);
            if(productFromDb != null)
            {
                productFromDb.Title = obj.Title;
                productFromDb.Author = obj.Author;
                productFromDb.Price = obj.Price;
                productFromDb.CategoryId = obj.CategoryId;
                productFromDb.ISBN = obj.ISBN;
                productFromDb.ListPrice = obj.ListPrice;
                productFromDb.Price100 = obj.Price100;
                productFromDb.Price50 = obj.Price50;
                productFromDb.ProductImages = obj.ProductImages;
            }
        }
    }
}

using AmazonShopping.Core.DataAcces.EntityFramework;
using AmazonShopping.DataAcces.Abstract;
using AmazonShopping.Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace AmazonShopping.DataAcces.Concrete.EntityFrameworkCore
{
    public class ProductDal : EfRepositoryBase<Product, AppDbContext>, IProductDal
    {
        public IEnumerable<Product> GetAllProducts(Expression<Func<Product, bool>>? filter)
        {
            using var context = new AppDbContext();
            return context.Products.Include(x => x.Category).Where(filter).ToList();
        }

        public Product GetProduct(Expression<Func<Product, bool>>? filter)
        {
            using var context = new AppDbContext();
            return context.Products.Include(x => x.Category).Where(filter).FirstOrDefault();
        }
    }
}

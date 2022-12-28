using AmazonShopping.Core.DataAcces;
using AmazonShopping.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace AmazonShopping.DataAcces.Abstract
{
    public interface IProductDal:IRepositoryBase<Product>
    {
        IEnumerable<Product> GetAllProducts(int Page, int Size,Expression<Func<Product, bool>>? filter=null);
        IEnumerable<Product> GetAllProducts(Expression<Func<Product, bool>>? filter=null);
        Product GetProduct(Expression<Func<Product, bool>>? filter);
        IEnumerable<Product> NewProducts();
        IEnumerable<Product> TrendingProducts();
    }
}

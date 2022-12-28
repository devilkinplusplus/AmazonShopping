using AmazonShopping.Core.Helpers.Result.Abstract;
using AmazonShopping.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static AmazonShopping.Entities.DTOs.ProductDTO;

namespace AmazonShopping.Business.Abstract
{
    public interface IProductService
    {
        IDataResult<Product> GetProduct(int id);
        IDataResult<IEnumerable<Product>> GetAllProducts();
        IDataResult<IEnumerable<Product>> GetAllProducts(int id, int size, int page);
        IDataResult<IEnumerable<Product>> GetAllActiveProducts(int size, int page);
        IResult CreateProduct(CreateProductDTO product, string userId);
        IResult EditProduct(EditProductDTO product, string userId);
        IResult DeleteProduct(Product product);
        IDataResult<IEnumerable<Product>> NewProducts();
        IDataResult<IEnumerable<Product>> TrendingProducts();
    }
}

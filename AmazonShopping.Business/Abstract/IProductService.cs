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
        Product GetProduct(int id);
        IEnumerable<Product> GetAllProducts();
        IEnumerable<Product> GetAllActiveProducts();
        void CreateProduct(CreateProductDTO product,string userId);
        void EditProduct(EditProductDTO product,string userId);
        void DeleteProduct(Product product);
    }
}

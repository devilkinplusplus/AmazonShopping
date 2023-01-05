using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AmazonShopping.Entities.DTOs
{
    public class ProductDTO
    {
        public record CreateProductDTO(string title,string name,string imageLink,int categoryId,int catalogId,int hit=0);
        public record EditProductDTO(int id,string title,string name, string imageLink, int categoryId,int catalogId);
        public record AddToFavourits(int productId);
    }
}

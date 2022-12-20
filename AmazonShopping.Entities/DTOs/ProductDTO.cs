using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AmazonShopping.Entities.DTOs
{
    public class ProductDTO
    {
        public record CreateProductDTO(string name,int categoryId,int hit=0);
        public record EditProductDTO(int id,string name,int categoryId);
    }
}

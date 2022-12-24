using AmazonShopping.Core.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AmazonShopping.Entities.Concrete
{
    public class Catalog:IEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public bool IsDeleted { get; set; }
        public virtual ICollection<Product> Products { get; set; }
    }
}

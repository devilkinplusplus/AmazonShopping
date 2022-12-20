using AmazonShopping.Core.Entity;
using AmazonShopping.Core.Entity.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AmazonShopping.Entities.Concrete
{
    public class Product:IEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string UserId { get; set; }
        public User User { get; set; }
        public int CategoryId{ get; set; }
        public Category Category { get; set; }
        public bool IsDeleted { get; set; }
        public int Hit { get; set; }
    }
}

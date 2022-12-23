using AmazonShopping.Core.Entity;
using AmazonShopping.Core.Entity.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AmazonShopping.Entities.Concrete
{
    public class Contact : IEntity
    {
        public int Id { get; set; }
        public string? Subject { get; set; }
        public string Email { get; set; }
        public string Message { get; set; }
        public DateTime Date { get; set; }
        public bool IsDeleted { get; set; }
    }
}

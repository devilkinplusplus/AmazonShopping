using AmazonShopping.Core.Entity;
using AmazonShopping.Core.Entity.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AmazonShopping.Entities.Concrete
{
    public class Reply:IEntity
    {
        public int Id { get; set; }
        public string UserId { get; set; }
        public User User { get; set; }
        public int ContactId { get; set; }
        public Contact Contact { get; set; }
        public string Content { get; set; }
        public DateTime Date { get; set; }
        public bool IsDeleted { get; set; }
    }
}

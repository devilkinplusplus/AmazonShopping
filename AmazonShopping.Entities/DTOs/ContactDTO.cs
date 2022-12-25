using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AmazonShopping.Entities.DTOs
{
    public class ContactDTO
    {
        public record ReplyDTO(string content,int contactId);
    }
}

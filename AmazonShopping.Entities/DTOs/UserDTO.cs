using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AmazonShopping.Entities.DTOs
{
    public class UserDTO
    {
        public record EditUserDTO(string firstName,string lastName,string password);
    }
}

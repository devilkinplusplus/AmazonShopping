using AmazonShopping.Core.Entity.Concrete;

namespace AmazonShopping.WebUI.Areas.Admin.Models
{
    public class AddUserRoleVM
    {
        public User User { get; set; }
        public IEnumerable<string> Roles { get; set; }
    }
}

using AmazonShopping.Entities.Concrete;

namespace AmazonShopping.WebUI.ViewModels
{
    public class HomeVM
    {
        public IEnumerable<Product> NewProducts { get; set; }
        public IEnumerable<Product> TrendingProducts { get; set; }
    }
}

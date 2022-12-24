using AmazonShopping.Core.DataAcces.EntityFramework;
using AmazonShopping.DataAcces.Abstract;
using AmazonShopping.Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static AmazonShopping.Entities.DTOs.ProductDTO;

namespace AmazonShopping.DataAcces.Concrete.EntityFrameworkCore
{
    public class FavouritDal : EfRepositoryBase<Favourit, AppDbContext>, IFavouritDal
    {
        public IEnumerable<Favourit> GetAll(string userId)
        {
            using var context = new AppDbContext();
            return context.Favourit.Include(x => x.Product).ThenInclude(x => x.Category)
                .Include(x => x.Product.Catalog)
                .Where(x => x.UserId == userId && x.IsDeleted == false).ToList();
        }
    }
}

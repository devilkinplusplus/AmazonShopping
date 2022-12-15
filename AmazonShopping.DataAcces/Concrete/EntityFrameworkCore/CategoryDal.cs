using AmazonShopping.Core.DataAcces.EntityFramework;
using AmazonShopping.DataAcces.Abstract;
using AmazonShopping.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AmazonShopping.DataAcces.Concrete.EntityFrameworkCore
{
    public class CategoryDal:EfRepositoryBase<Category,AppDbContext>,ICategoryDal
    {
    }
}

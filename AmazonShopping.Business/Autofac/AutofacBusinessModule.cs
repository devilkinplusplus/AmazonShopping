using AmazonShopping.Business.Abstract;
using AmazonShopping.Business.Concrete;
using AmazonShopping.DataAcces.Abstract;
using AmazonShopping.DataAcces.Concrete.EntityFrameworkCore;
using Autofac;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AmazonShopping.Business.Autofac
{
    public class AutofacBusinessModule:Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<CategoryDal>().As<ICategoryDal>();
            builder.RegisterType<CategoryManager>().As<ICategoryService>();

            builder.RegisterType<SubCategoryDal>().As<ISubCategoryDal>();
            builder.RegisterType<SubCategoryManager>().As<ISubCategoryService>();

            builder.RegisterType<CategorySubDal>().As<ICategorySubDal>();
            builder.RegisterType<CategorySubManager>().As<ICategorySubService>();
        }
    }
}

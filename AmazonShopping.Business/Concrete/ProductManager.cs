using AmazonShopping.Business.Abstract;
using AmazonShopping.Business.Constants;
using AmazonShopping.Business.Validators;
using AmazonShopping.Core.Entity.Concrete;
using AmazonShopping.Core.Helpers.Result.Abstract;
using AmazonShopping.Core.Helpers.Result.Concrete.ErrorResult;
using AmazonShopping.Core.Helpers.Result.Concrete.SuccessResults;
using AmazonShopping.DataAcces.Abstract;
using AmazonShopping.Entities.Concrete;
using AutoMapper;
using FluentValidation.Results;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;
using X.PagedList;
using static AmazonShopping.Entities.DTOs.ProductDTO;

namespace AmazonShopping.Business.Concrete
{
    public class ProductManager : IProductService
    {
        private readonly IProductDal _productDal;
        private readonly IMapper _mapper;
        public ProductManager(IProductDal productDal, IMapper mapper)
        {
            _productDal = productDal;
            _mapper = mapper;
        }

        public IResult CreateProduct(CreateProductDTO product, string userId)
        {
            try
            {
                var mapper = _mapper.Map<Product>(product);
                mapper.Title = product.title;
                mapper.Name = product.name;
                mapper.UserId = userId;
                mapper.CategoryId = product.categoryId;
                mapper.CatalogId = product.catalogId;
                mapper.Hit = product.hit;
                mapper.ImageLink = product.imageLink;
                ProductValidator validations = new ProductValidator();
                ValidationResult result = validations.Validate(mapper);
                if (result.IsValid)
                {
                    _productDal.Add(mapper);
                    return new SuccessResult(Messages.SuccessMessage);
                }
                return new ErrorResult(Messages.ErrorMessage);
            }
            catch (Exception ex)
            {
                return new ErrorResult(ex.Message);
            }
        }

        public IResult DeleteProduct(Product product)
        {
            try
            {
                var data = _productDal.Get(x => x.Id == product.Id);
                data.IsDeleted = true;
                _productDal.Update(data);
                return new SuccessResult(Messages.SuccessMessage);
            }
            catch (Exception ex)
            {
                return new ErrorResult(ex.Message);
            }
        }

        public IResult EditProduct(EditProductDTO product, string userId)
        {
            try
            {
                var data = _productDal.Get(x => x.Id == product.id);
                var mapper = _mapper.Map<Product>(product);
                data.Title = product.title;
                data.UserId = userId;
                data.Name = product.name;
                data.CategoryId = product.categoryId;
                data.CatalogId = product.catalogId;
                data.ImageLink = product.imageLink;

                ProductValidator validations = new ProductValidator();
                ValidationResult result = validations.Validate(data);
                if (result.IsValid)
                {
                    _productDal.Update(data);
                    return new SuccessResult(Messages.SuccessMessage);
                }
                return new ErrorResult(Messages.ErrorMessage);
            }
            catch (Exception ex)
            {
                return new ErrorResult(ex.Message);
            }
        }

        public IDataResult<IEnumerable<Product>> GetAllActiveProducts(int size, int page = 1)
        {
            try
            {
                var data = _productDal.GetAllProducts(x => x.IsDeleted == false)
                                      .ToPagedList(page, size);

                if (data.Count() != 0)
                    return new SuccessDataResult<IEnumerable<Product>>(data);
                return new ErrorDataResult<IEnumerable<Product>>(Messages.CannotBeNull);
            }
            catch (Exception ex)
            {
                return new ErrorDataResult<IEnumerable<Product>>(ex.Message);
            }
        }

        public IDataResult<IEnumerable<Product>> GetAllProducts()
        {
            try
            {
                var data = _productDal.GetAllProducts();
                if (data.Count() != 0)
                    return new SuccessDataResult<IEnumerable<Product>>(data);
                return new ErrorDataResult<IEnumerable<Product>>(Messages.CannotBeNull);
            }
            catch (Exception ex)
            {
                return new ErrorDataResult<IEnumerable<Product>>(ex.Message);
            }

        }

        public IDataResult<IEnumerable<Product>> GetAllProducts(int id, int size, int page = 1)
        {
            try
            {
                var data = _productDal.GetAllProducts(x => x.IsDeleted == false && x.CategoryId == id)
                                        .ToPagedList(page, size);
                if (data.Count() != 0)
                    return new SuccessDataResult<IEnumerable<Product>>(data);
                return new ErrorDataResult<IEnumerable<Product>>(Messages.CannotBeNull);
            }
            catch (Exception ex)
            {
                return new ErrorDataResult<IEnumerable<Product>>(ex.Message);
            }

        }

        public IDataResult<Product> GetProduct(int id)
        {
            try
            {
                var data = _productDal.GetProduct(x => x.Id == id);
                if (data != null)
                    return new SuccessDataResult<Product>(data);
                return new ErrorDataResult<Product>(Messages.CannotBeNull);
            }
            catch (Exception ex)
            {
                return new ErrorDataResult<Product>(ex.Message);
            }
        }

        public IDataResult<Product> IncreaseHit(int id,int num)
        {
            try
            {
                var data = _productDal.Get(x => x.Id == id);
                data.Hit += num;
                _productDal.Update(data);
                return new SuccessDataResult<Product>(data);
            }
            catch (Exception e)
            {
                return new ErrorDataResult<Product>(e.Message);
            }
        }

        public IDataResult<IEnumerable<Product>> NewProducts()
        {
            try
            {
                var values = _productDal.NewProducts();
                if (values.Count() != 0)
                    return new SuccessDataResult<IEnumerable<Product>>(values);
                return new ErrorDataResult<IEnumerable<Product>>(Messages.CannotBeNull);
            }
            catch (Exception ex)
            {
                return new ErrorDataResult<IEnumerable<Product>>(ex.Message);
            }
        }

        public IDataResult<IEnumerable<Product>> TrendingProducts()
        {
            try
            {
                var values = _productDal.TrendingProducts();
                if (values.Count() != 0)
                    return new SuccessDataResult<IEnumerable<Product>>(values);
                return new ErrorDataResult<IEnumerable<Product>>(Messages.CannotBeNull);
            }
            catch (Exception ex)
            {
                return new ErrorDataResult<IEnumerable<Product>>(ex.Message);
            }
        }
    }
}

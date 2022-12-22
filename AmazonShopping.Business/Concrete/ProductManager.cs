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
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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

        public void CreateProduct(CreateProductDTO product, string userId)
        {
            try
            {
                var mapper = _mapper.Map<Product>(product);
                mapper.Title = product.title;
                mapper.Name = product.name;
                mapper.UserId = userId;
                mapper.CategoryId = product.categoryId;
                mapper.Hit = product.hit;
                ProductValidator validations = new ProductValidator();
                ValidationResult result = validations.Validate(mapper);
                if (result.IsValid)
                {
                    _productDal.Add(mapper);
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public void DeleteProduct(Product product)
        {
            try
            {
                var data = _productDal.Get(x => x.Id == product.Id);
                data.IsDeleted = true;
                _productDal.Update(data);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public void EditProduct(EditProductDTO product, string userId)
        {
            try
            {
                var data = _productDal.Get(x => x.Id == product.id);
                var mapper = _mapper.Map<Product>(product);
                data.Title = product.title;
                data.UserId = userId;
                data.Name = product.name;
                data.CategoryId = product.categoryId;

                ProductValidator validations = new ProductValidator();
                ValidationResult result = validations.Validate(data);
                if (result.IsValid)
                {
                    _productDal.Update(data);
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public IEnumerable<Product> GetAllActiveProducts()
        {
            try
            {
                var data = _productDal.GetAllProducts(x => x.IsDeleted == false);

                if (data.Count() != 0)
                    return data;
                return data;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public IEnumerable<Product> GetAllProducts()
        {
            try
            {
                var data = _productDal.GetAllProducts();
                if (data.Count() != 0)
                    return data;
                return data;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

        }

        public Product GetProduct(int id)
        {
            try
            {
                var data = _productDal.GetProduct(x => x.Id == id);
                return data;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public IEnumerable<Product> NewProducts()
        {
            try
            {
                return _productDal.NewProducts();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public IEnumerable<Product> TrendingProducts()
        {
            try
            {
                return _productDal.TrendingProducts();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}

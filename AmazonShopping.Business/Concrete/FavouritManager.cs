using AmazonShopping.Business.Abstract;
using AmazonShopping.Core.Helpers.Result.Abstract;
using AmazonShopping.Core.Helpers.Result.Concrete.ErrorResult;
using AmazonShopping.Core.Helpers.Result.Concrete.SuccessResults;
using AmazonShopping.DataAcces.Abstract;
using AmazonShopping.DataAcces.Concrete;
using AmazonShopping.Entities.Concrete;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using static AmazonShopping.Entities.DTOs.ProductDTO;

namespace AmazonShopping.Business.Concrete
{
    public class FavouritManager : IFavouritService
    {
        private readonly IFavouritDal _favouritDal;
        private readonly IMapper _mapper;
        public FavouritManager(IFavouritDal favouritDal, IMapper mapper)
        {
            _favouritDal = favouritDal;
            _mapper = mapper;
        }

        public IDataResult<Favourit> Add(AddToFavourits favourit,string userId)
        {
            try
            {
                var mapper = _mapper.Map<Favourit>(favourit);

                using var context = new AppDbContext();
                var isDataExist = context.Favourit.FirstOrDefault(x=>x.UserId== userId && x.ProductId==favourit.productId && x.IsDeleted==false);
                if (isDataExist!=null)
                {
                    return new SuccessDataResult<Favourit>(isDataExist); ;
                }
                mapper.ProductId = favourit.productId;
                mapper.UserId = userId;
                mapper.Date = DateTime.Now;
                mapper.IsDeleted = false;
                 _favouritDal.Add(mapper);
                return new SuccessDataResult<Favourit>(mapper);
            }
            catch (Exception ex)
            {
                return new ErrorDataResult<Favourit>(ex.Message);
            }
        }

        public IDataResult<Favourit> Edit(int id)
        {
            try
            {
                var currentData = _favouritDal.Get(x=>x.Id == id);
                currentData.IsDeleted = true;
                _favouritDal.Update(currentData);
                return  new SuccessDataResult<Favourit>(currentData);;
            }
            catch (Exception ex)
            {
                return new ErrorDataResult<Favourit>(ex.Message);
            }
        }

        public IEnumerable<Favourit> GetFavouritList(string userId)
        {
            try
            {
                var values = _favouritDal.GetAll(userId);
                return values;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

        }
    }
}

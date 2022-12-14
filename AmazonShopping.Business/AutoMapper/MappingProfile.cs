using AmazonShopping.Core.Entity.Concrete;
using AmazonShopping.Entities.Concrete;
using AmazonShopping.Entities.DTOs;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static AmazonShopping.Entities.DTOs.ContactDTO;
using static AmazonShopping.Entities.DTOs.ProductDTO;
using static AmazonShopping.Entities.DTOs.UserDTO;

namespace AmazonShopping.Business.AutoMapper
{
    public class MappingProfile:Profile
    {
        public MappingProfile()
        {
            CreateMap<RegisterDTO, User>().ReverseMap();
            CreateMap<LoginDTO, User>().ReverseMap();
            CreateMap<CreateProductDTO, Product>().ReverseMap();
            CreateMap<EditProductDTO, Product>().ReverseMap();
            CreateMap<AddToFavourits,Favourit>().ReverseMap();
            CreateMap<ReplyDTO, Reply>().ReverseMap();
            CreateMap<EditUserDTO,User>().ReverseMap();
        }
    }
}

using AmazonShopping.Core.Entity.Concrete;
using AmazonShopping.Entities.DTOs;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AmazonShopping.Business.AutoMapper
{
    public class MappingProfile:Profile
    {
        public MappingProfile()
        {
            CreateMap<RegisterDTO, User>().ReverseMap();

            CreateMap<LoginDTO, User>().ReverseMap();
        }
    }
}

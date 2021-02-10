using AutoMapper;
using OnLineShop.Core.Entities;
using OnLineShop.Core.Entities.Identity;
using OnLineShop.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OnLineShop.Helpers
{
    public class MappingProfiles : Profile
    {
        public MappingProfiles()
        {
            CreateMap<Product, ProductToReturnDto>()
                .ForMember(d => d.ProductBrands, o => o.MapFrom(s => s.ProductBrands.Name))
                .ForMember(d => d.ProductTypes, o => o.MapFrom(s => s.ProductTypes.Name))
                .ForMember(d => d.PictureUrl, o => o.MapFrom<ProductUrlResolve>());
            CreateMap<Adress, AdressDto>().ReverseMap();
            CreateMap<CustomerBasketDto, CustomerBasket>();
            CreateMap<BasketItemDto, BasketItem>();
        }
    }
}

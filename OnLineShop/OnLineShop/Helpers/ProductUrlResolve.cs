using AutoMapper;
using Microsoft.Extensions.Configuration;
using OnLineShop.Core.Entities;
using OnLineShop.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OnLineShop.Helpers
{
    public class ProductUrlResolve : IValueResolver<Product, ProductToReturnDto, string>
    {
        private readonly IConfiguration _config;
        public ProductUrlResolve(IConfiguration config)
        {
            _config = config;
        }
        public string Resolve(
            Product source, 
            ProductToReturnDto destination, 
            string destMember, 
            ResolutionContext context)
        {
            if (!string.IsNullOrEmpty(source.PictureUrl))
            {
                return _config["ApiUrl"] + source.PictureUrl;
            }

            return null;
        }
    }
}

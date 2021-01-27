using OnLineShop.Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace OnLineShop.Core.Specifications
{
    public class ProductsWithTypesAndBrandsSpecification : BaseSpecification<Product>
    {
        public ProductsWithTypesAndBrandsSpecification()
        {
            AddInclude(x => x.ProductTypes);
            AddInclude(x => x.ProductBrands);
        }

        public ProductsWithTypesAndBrandsSpecification(int id) : base(x => x.Id == id)
        {
            AddInclude(x => x.ProductTypes);
            AddInclude(x => x.ProductBrands);
        }
    }
}

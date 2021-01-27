using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace OnLineShop.Core.Entities
{
    public class Product : BaseEntity
    {
        
     
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public string PictureUrl { get; set; }

        public int ProductTypeId { get; set; }

        [ForeignKey("ProductTypeId")]
        public ProductType ProductTypes { get; set; }

        public int ProductBrandId { get; set; }

        [ForeignKey("ProductBrandId")]
        public ProductBrand ProductBrands { get; set; }
      
    }
}

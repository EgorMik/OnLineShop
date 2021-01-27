using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace OnLineShop.Core.Entities
{
    public class ProductType : BaseEntity
    {
       
        public string Name { get; set; }

        //public ICollection<Product> Products { get; set; }
        //public Product Products { get; set; }


    }
}
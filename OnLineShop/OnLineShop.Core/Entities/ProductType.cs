using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace OnLineShop.Core.Entities
{
    public class ProductType
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }

        public ICollection<Product> Products { get; set; }



    }
}
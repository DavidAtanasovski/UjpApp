using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WorldUjp.ViewModel
{
    public class ProductViewModel
    {
        [Required, Display(Name = "Product Name")]
        public string Name { get; set; }
        [Required]
        public double? Price { get; set; }
        [Required, Display(Name ="DDV")]
        public int? DDVId { get; set; }
        public int TaxPayerId { get; set; }
    }
}

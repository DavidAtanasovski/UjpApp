using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Core
{
    public class FiscalReceipt
    {
        public FiscalReceipt()
        {
            Products = new List<Product>();
        }

        public int Id { get; set; }
        public List<Product> Products { get; set; }

        [Required]
        public int? TaxPayerId { get; set; }
        public TaxPayer TaxPayer { get; set; }
    }
}

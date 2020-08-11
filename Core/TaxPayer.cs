using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Core
{
    public class TaxPayer
    {
        public int Id { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        [Required]
        public int? CountryId { get; set; }

        public Country Country { get; set; }

        public List<Product> Products { get; set; }

        public TaxPayer()
        {
            Products = new List<Product>();
        }
    }
}

using System;
using System.Collections.Generic;
using System.Text;

namespace Core
{
    public class Country
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public double? TaxReturnPolicy { get; set; }

        public List<TaxPayer> TaxPayers { get; set; }
    }
}

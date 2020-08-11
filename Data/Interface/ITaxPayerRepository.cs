using Core;
using System.Collections.Generic;

namespace Data.Interface
{
    public interface ITaxPayerRepository 
    {
        List<TaxPayer> GetTaxPayers();
        TaxPayer Get(int id);
        TaxPayer GetTaxPayer(int id);
    }
}

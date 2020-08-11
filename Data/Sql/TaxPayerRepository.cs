using Core;
using Data.Interface;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace Data.Sql
{
    public class TaxPayerRepository : ITaxPayerRepository
    {
        private readonly UjpDbContext ujpDbContext;

        public TaxPayerRepository(UjpDbContext ujpDbContext) 
        {
            this.ujpDbContext = ujpDbContext;
        }

        public TaxPayer Get(int id)
        {
            return ujpDbContext.TaxPayers.SingleOrDefault(t => t.Id == id);
        }

        public TaxPayer GetTaxPayer(int id)
        {
            return ujpDbContext.TaxPayers
                .Include(x => x.Products)
                .ThenInclude(x => x.DDV)
                .SingleOrDefault(t => t.Id == id);
        }

        public List<TaxPayer> GetTaxPayers()
        {
            return ujpDbContext.TaxPayers
                .Include(x => x.Country)
                .Include(x => x.Products)
                .ThenInclude(x => x.DDV)
                .ToList();
        }
    }
}

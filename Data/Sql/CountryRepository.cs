using Core;
using Data.Interface;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace Data.Sql
{
    public class CountryRepository : ICountryRepository
    {
        private readonly UjpDbContext ujpDbContext;

        public CountryRepository(UjpDbContext ujpDbContext) 
        {
            this.ujpDbContext = ujpDbContext;
        }

        public List<Country> GetAll()
        {
            return ujpDbContext.Countries.Include(x=>x.TaxPayers).ToList();
        }
    }
}

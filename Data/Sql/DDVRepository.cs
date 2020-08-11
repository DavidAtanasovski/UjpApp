using Core;
using Data.Interface;
using System.Collections.Generic;
using System.Linq;

namespace Data.Sql
{
    public class DDVRepository : IDDVRepository
    {
        private readonly UjpDbContext ujpDbContext;

        public DDVRepository(UjpDbContext ujpDbContext) 
        {
            this.ujpDbContext = ujpDbContext;
        }

        public DDV Get(int id)
        {
            return ujpDbContext.DDVs.SingleOrDefault(d => d.Id == id);
        }

        public List<DDV> GetAll()
        {
            return ujpDbContext.DDVs.ToList();
        }
    }
}

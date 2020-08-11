using Core;
using Data.Interface;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace Data.Sql
{
    public class FiscalReceiptRepository: IFiscalReceiptRepository
    {
        private readonly UjpDbContext ujpDbContext;

        public FiscalReceiptRepository(UjpDbContext ujpDbContext) 
        {
            this.ujpDbContext = ujpDbContext;
        }

        public void Commit()
        {
            ujpDbContext.SaveChanges();
        }

        public FiscalReceipt Create(FiscalReceipt fiscalReceipt)
        {
            ujpDbContext.FiscalReceipt.Add(fiscalReceipt);
            return fiscalReceipt;
        }

        public List<FiscalReceipt> GetFiscalList()
        {
            return ujpDbContext.FiscalReceipt
                .Include(x => x.TaxPayer)
                .Include(x => x.Products)
                .ToList();
        }
    }
}

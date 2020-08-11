using Core;
using System;
using System.Collections.Generic;

namespace Data.Interface
{
    public interface IFiscalReceiptRepository
    {
        List<FiscalReceipt> GetFiscalList();
        FiscalReceipt Create(FiscalReceipt fiscalReceipt);
        void Commit();
    }
}

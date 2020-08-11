using System.Collections.Generic;
using System.Linq;
using Data.Interface;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace WorldUjp.Pages
{
    public class FiscalListModel : PageModel
    {
        private readonly IFiscalReceiptRepository fiscalReceiptRepository;

        [BindProperty(SupportsGet = true)]
        public string SearchTerm { get; set; }

        [TempData]
        public string Message { get; set; }
        public IEnumerable<Core.FiscalReceipt> FiscalReceipts { get; set; }

        public FiscalListModel(IFiscalReceiptRepository fiscalReceiptRepository)
        {
            this.fiscalReceiptRepository = fiscalReceiptRepository;
        }

        public void OnGet()
        {
            FiscalReceipts = fiscalReceiptRepository.GetFiscalList().OrderBy(fr => fr.TaxPayer.FirstName);
        }
    }
}
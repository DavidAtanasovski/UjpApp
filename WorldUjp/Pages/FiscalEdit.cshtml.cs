using System.Collections.Generic;
using System.Linq;
using Core;
using Data.Interface;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace WorldUjp.Pages
{
    public class FiscalEditModel : PageModel
    {
        private readonly ITaxPayerRepository taxPayerRepository;
        private readonly IFiscalReceiptRepository fiscalReceiptRepository;
        private readonly IDDVRepository ddvRepository;

        [BindProperty]
        public Core.FiscalReceipt FiscalReceipt { get; set; }

        public Product Product{ get; set; }

        public string Message { get; set; }

        public IEnumerable<SelectListItem> TaxPayers { get; set; }
        public IEnumerable<SelectListItem> DDVs { get; private set; }

        public FiscalEditModel(ITaxPayerRepository taxPayerRepository, IFiscalReceiptRepository fiscalReceiptRepository, IDDVRepository ddvRepository)
        {
            this.taxPayerRepository = taxPayerRepository;
            this.fiscalReceiptRepository = fiscalReceiptRepository;
            this.ddvRepository = ddvRepository;
        }

        public IActionResult OnGet()
        {
            FiscalReceipt = new Core.FiscalReceipt();
            Product = new Product();
            SetUpStaticData();
            return Page();
        }

        private void SetUpStaticData()
        {
            TaxPayers = new SelectList(taxPayerRepository.GetAll().Select(p => new { Id = p.Id, Display = $"{p.FirstName} {p.LastName}" }), "Id", "Display");
            DDVs = new SelectList(ddvRepository.GetAll().Select(p => new { Id = p.Id, Display = p.Tax.ToString("p") }), "Id", "Display");
        }

        public IActionResult OnPost()
        {
            if (ModelState.IsValid)
            {
                FiscalReceipt.Products.ForEach(p => p.DDV = null);
                FiscalReceipt = fiscalReceiptRepository.Create(FiscalReceipt);
                TempData["Message"] = "The Object is created!";

                fiscalReceiptRepository.Commit();
                return RedirectToPage("./FiscalList");
            }

            SetUpStaticData();
            return Page();
        }

        public IActionResult OnPostBuy(Product product)
        {
            if (ModelState.IsValid)
            {
                product.DDV = ddvRepository.Get(product.DDVId.GetValueOrDefault());
                FiscalReceipt.Products.Add(product);
                ModelState.Clear();
            }

            SetUpStaticData();
            return Page();
        }
    }
}
using System.Collections.Generic;
using System.Linq;
using Data.Interface;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using WorldUjp.ViewModel;

namespace WorldUjp.Pages.Product
{
    public class CreateModel : PageModel
    {
        private readonly IProductRepository productRepository;
        private readonly ITaxPayerRepository taxPayerRepository;
        private readonly IDDVRepository ddvRepository;

        public Core.TaxPayer TaxPayer { get; set; }

        [BindProperty]
        public ProductViewModel Product { get; set; }

        public IEnumerable<SelectListItem> DDVs { get; private set; }

        public CreateModel(IProductRepository productRepository, ITaxPayerRepository taxPayerRepository, IDDVRepository ddvRepository)
        {
            this.productRepository = productRepository;
            this.taxPayerRepository = taxPayerRepository;
            this.ddvRepository = ddvRepository;
        }

        public IActionResult OnGet(int id)
        {           
            Product = new ProductViewModel { TaxPayerId = id };

            SetUpStaticData();
            return Page();
        }

        private void SetUpStaticData()
        {
            TaxPayer = taxPayerRepository.Get(Product.TaxPayerId);
            DDVs = new SelectList(ddvRepository.GetAll().Select(p => new { Id = p.Id, Display = p.Tax.ToString("p") }), "Id", "Display");
        }

        public IActionResult OnPost()
        {
            if (ModelState.IsValid)
            {
                productRepository.Create(new Core.Product 
                {
                    TaxPayerId = Product.TaxPayerId,
                    DDVId = Product.DDVId.Value,
                    Name = Product.Name,
                    Price = Product.Price.Value
                });
                productRepository.Commit();
                return RedirectToPage("./Index", new { id = Product.TaxPayerId });
            }

            SetUpStaticData();
            return Page();
        }
    }
}
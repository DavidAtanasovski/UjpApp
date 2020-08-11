using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core;
using Data.Interface;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace WorldUjp.Pages
{
    public class ProductModel : PageModel
    {
        private readonly IProductRepository productRepository;
        private readonly ITaxPayerRepository taxPayerRepository;
        private readonly IDDVRepository ddvRepository;

        public Core.TaxPayer TaxPayer { get; set; }

        [BindProperty]
        public Product Product { get; set; }

        [BindProperty]
        public List<Product> Products { get; set; }

        public IEnumerable<SelectListItem> DDVs { get; private set; }

        public ProductModel(IProductRepository productRepository, ITaxPayerRepository taxPayerRepository, IDDVRepository ddvRepository)
        {
            this.productRepository = productRepository;
            this.taxPayerRepository = taxPayerRepository;
            this.ddvRepository = ddvRepository;
        }

        public IActionResult OnGet(int id)
        {
            TaxPayer = taxPayerRepository.Get(id);
            Product = new Product();
            SetUpStaticData();
            return Page();
        }

        private void SetUpStaticData()
        {            
            DDVs = new SelectList(ddvRepository.GetAll().Select(p => new { Id = p.Id, Display = p.Tax.ToString("p") }), "Id", "Display");
        }

        public IActionResult OnPost()
        {
            if (ModelState.IsValid)
            {
                productRepository.Create(Products);
                productRepository.Commit();
                return RedirectToPage("/TaxPayers/Index");
            }

            SetUpStaticData();
            return Page();
        }

        public IActionResult OnPostBuy(Product product)
        {
            if (ModelState.IsValid)
            {
                product.DDV = ddvRepository.Get(product.DDVId.GetValueOrDefault());
                Products.Add(product);
                ModelState.Clear();
            }

            SetUpStaticData();
            return Page();
        }
    }
}
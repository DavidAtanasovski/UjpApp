using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Data.Interface;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace WorldUjp.Pages.TaxPayer
{
    public class EditModel : PageModel
    {
        private readonly ITaxPayerRepository taxPayerRepository;
        private readonly ICountryRepository countryRepository;

        [BindProperty]
        public Core.TaxPayer TaxPayer { get; set; }

        public IEnumerable<SelectListItem> Countries { get; set; }

        public EditModel(ITaxPayerRepository taxPayerRepository, ICountryRepository countryRepository)
        {
            this.taxPayerRepository = taxPayerRepository;
            this.countryRepository = countryRepository;
        }

        public IActionResult OnGet(int? id)
        {
            if (id.HasValue)
            {
                TaxPayer = taxPayerRepository.Get(x => x.Id == id.Value);
            }
            else
            {
                TaxPayer = new Core.TaxPayer();
            }

            SetStaticData();
            return Page();
        }

        public IActionResult OnPost()
        {
            if (ModelState.IsValid)
            {
                if (TaxPayer.Id == 0)
                {
                    TaxPayer = taxPayerRepository.Add(TaxPayer);
                    TempData["Message"] = "The Object is created!";
                }
                else
                {
                    TaxPayer = taxPayerRepository.Update(TaxPayer);
                    TempData["Message"] = "The Object is updated!";
                }

                taxPayerRepository.Commit();
                return RedirectToPage("./Index");
            }

            SetStaticData();
            return Page();
        }

        private void SetStaticData()
        {
            var countries = countryRepository.GetAll().ToList().Select(p => new { Id = p.Id, Display = p.Name });
            Countries = new SelectList(countries, "Id", "Display");
        }
    }
}
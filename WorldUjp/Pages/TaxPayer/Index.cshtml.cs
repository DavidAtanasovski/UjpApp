using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Data.Interface;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace WorldUjp.Pages.TaxPayer
{   
    public class IndexModel : PageModel
    {
        private readonly ITaxPayerRepository taxPayerRepository;

        public List<Core.TaxPayer> TaxPayers { get; set; }

        public IndexModel(ITaxPayerRepository taxPayerRepository)
        {
            this.taxPayerRepository = taxPayerRepository;
        }
        
        public void OnGet()
        {
            TaxPayers = taxPayerRepository.GetTaxPayers();
        }
    }
}
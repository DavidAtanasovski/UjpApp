using System;
using System.Collections.Generic;
using System.Linq;
using Data.Interface;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace WorldUjp.Pages.Country
{
    public class IndexModel : PageModel
    {
        private readonly ICountryRepository countryRepository;

        public List<Core.Country> Countries { get; set; }

        public IndexModel(ICountryRepository countryRepository)
        {
            this.countryRepository = countryRepository;
        }
        
        public void OnGet()
        {
            Countries = countryRepository.GetAll();
        }
    }
}
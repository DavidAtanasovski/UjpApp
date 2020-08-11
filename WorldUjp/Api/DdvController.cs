using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Data.Interface;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WorldUjp.Api
{
    [Route("api/[controller]")]
    [ApiController]
    public class DdvController : ControllerBase
    {
        private readonly IDDVRepository ddvRepository;

        public DdvController(IDDVRepository ddvRepository)
        {
            this.ddvRepository = ddvRepository;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            return Ok(ddvRepository.GetAll());
        }
    }
}
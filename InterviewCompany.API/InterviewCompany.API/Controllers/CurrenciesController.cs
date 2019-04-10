using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using InterviewCompany.Domain.Documents;
using InterviewCompany.Service;
using InterviewCompany.Service.Validators;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace InterviewCompany.API.Controllers
{
    [Produces("application/json")]
    [Route("api/Currencies")]
    public class CurrenciesController : Controller
    {
        private readonly CurrencyService _currencyService;

        public CurrenciesController(CurrencyService currencyService)
        {
            this._currencyService = currencyService;
        }

        // GET: api/Currencies
        [HttpGet]
        public IActionResult GetAvaiableCurrencies()
        {
            return Ok(_currencyService.GetAvailableCurrencies());
        }

        // POST api/Currencies
        [HttpPost]
        public async Task<IActionResult> Post([FromBody]Currency currency)
        {
            if (!ModelState.IsValid)
                return BadRequest();
            var results = await _currencyService.InsertCurrencyAsync(currency);

            if (results.Status == ValidationStatus.Error)
                return BadRequest(results.ErrorMessages);

            return Created("api/Currencies", "Created");
        }

        // PUT api/Currencies/
        [HttpPut()]
        public async Task<IActionResult> Delete([FromBody]Currency currency)
        {
            var results = await _currencyService.UpdateCurrencyAsync(currency);

            if (results.Status == ValidationStatus.Error)
                return BadRequest(results.ErrorMessages);

            return NoContent();
        }
    }
}
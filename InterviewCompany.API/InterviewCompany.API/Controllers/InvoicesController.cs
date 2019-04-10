using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using InterviewCompany.Domain.Model;
using InterviewCompany.Service;
using InterviewCompany.Service.Validators;
using Microsoft.AspNetCore.Mvc;
using Serilog;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace InterviewCompany.API.Controllers
{
    [Produces("application/json")]
    [Route("api/Invoices")]
    public class InvoicesController : Controller
    {
        private readonly IInvoiceService _invoiceService;

        public InvoicesController(IInvoiceService invoiceService)
        {
            this._invoiceService = invoiceService;
        }

        // GET: api/Invoices
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await _invoiceService.GetAllAsync());
        }

        // GET api/Invoices/5A
        [HttpGet, Route("{invoiceNumber}")]
        public async Task<IActionResult> GetByInvoiceNumber(int invoiceNumber)
        {
            return Ok(await _invoiceService.GetByNumberAsync(invoiceNumber));
        }

        // POST api/Invoices
        [HttpPost]
        public async Task<IActionResult> Post([FromBody]AddInvoiceModel invoiceModel)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            var response = await _invoiceService.InsertOneAsync(invoiceModel);

            if(response.ValidationResult.Status == ValidationStatus.Error)
            {
                foreach (var error in response.ValidationResult.ErrorMessages)
                    Log.Error(error);

                return BadRequest(response.ValidationResult.ErrorMessages);
            }

            return Created("api/Invoices", response.InvoiceNumber);
        }
        
        // DELETE api/Invoices/5
        [HttpDelete("{number}")]
        public async Task<IActionResult> Delete(int number)
        {
            if (number <= 0)
                return BadRequest();

            var result = await _invoiceService.RemoveOneAsync(number);

            if (result)
                return NoContent();

            return NotFound();
        }
    }
}

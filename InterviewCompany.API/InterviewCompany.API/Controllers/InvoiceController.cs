using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using InterviewCompany.Domain.Model;
using InterviewCompany.Service;
using Microsoft.AspNetCore.Mvc;

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
        public async Task<IActionResult> GetByInvoiceNumber(string invoiceNumber)
        {
            return Ok(await _invoiceService.GetByNumberAsync(invoiceNumber));
        }

        // POST api/Invoices
        [HttpPost]
        public async Task<IActionResult> Post([FromBody]AddInvoiceModel invoiceModel)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            return Created("api/Invoices", await _invoiceService.InsertOneAsync(invoiceModel));
        }

        // DELETE api/Invoices/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            var result = await _invoiceService.RemoveOneAsync(id);

            if (result)
                return NoContent();

            return NotFound();
        }
    }
}

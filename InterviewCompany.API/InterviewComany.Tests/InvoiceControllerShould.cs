using Xunit;
using Xunit.Abstractions;
using Moq;
using InterviewCompany.Domain.Model;
using InterviewCompany.Tests.Data;
using InterviewCompany.Domain.Repositories.Interfaces;
using InterviewCompany.Service;
using InterviewCompany.API.Controllers;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using InterviewCompany.Service.ResponseModel;

namespace InterviewCompany.Tests
{
    // Class fixture tells xUnit to initialiaze instance of InvoiceFixture class before running any test from this class.
    // Fixture class can contain for example test data
    public class InvoiceControllerShould : IClassFixture<InvoiceFixture>, IClassFixture<InvoiceControllerFixture>
    {
        private readonly ITestOutputHelper _output;
        private readonly InvoiceFixture _invoicefixture;
        private readonly InvoiceControllerFixture _invoiceControllerfixture;

        public InvoiceControllerShould(ITestOutputHelper output, InvoiceFixture invoicefixture, InvoiceControllerFixture invoiceControllerfixture)
        {
            _output = output;
            _invoicefixture = invoicefixture;
            _invoiceControllerfixture = invoiceControllerfixture;
        }

        [Fact]
        public async Task ReturnValidInvoiceNumber()
        {
            var result = await _invoiceControllerfixture.Controller.Post(_invoicefixture.Invoice);

            Assert.IsType<CreatedResult>(result);
            var resultValue = ((CreatedResult)result).Value;
            _output.WriteLine($"Post method of invoices controller returned: {resultValue} within CreatedResult.");
            Assert.IsType<int>(resultValue);
            Assert.True((int)resultValue > 0);
        }

        [Fact]
        public async Task NotAllowPostInvalidInvoiceModel()
        {
            var mockService = new Mock<IInvoiceService>();
            mockService.Setup(serv => serv.InsertOneAsync(_invoicefixture.Invoice)).ReturnsAsync(new InvoiceInsertResponse { InvoiceNumber = 1});
            var invoicesController = new InvoicesController(mockService.Object);
            invoicesController.ModelState.AddModelError("BillTo", "Required");

            var result = await invoicesController.Post(_invoicefixture.Invoice);

            Assert.IsType<BadRequestResult>(result);
        }
        
        
    }
}

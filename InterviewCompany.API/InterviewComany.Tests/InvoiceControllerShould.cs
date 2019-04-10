using Xunit;
using Xunit.Abstractions;
using Moq;
using InterviewCompany.Domain.Model;
using InterviewCompany.Tests.Data;
using InterviewCompany.Domain.Repositories.Interfaces;
using InterviewCompany.Service;
using InterviewCompany.API.Controllers;

namespace InterviewCompany.Tests
{
    // Class fixture tells xUnit to initialiaze instance of InvoiceFixture class before running any test from this class.
    // Fixture class can contain for example test data
    public class InvoiceControllerShould : IClassFixture<InvoiceFixture>
    {
        private readonly ITestOutputHelper _output;
        private readonly InvoiceFixture _fixture;

        public InvoiceControllerShould(ITestOutputHelper output, InvoiceFixture fixture)
        {
            _output = output;
            _fixture = fixture;
        }

        [Fact]
        public void NotAllowPostInvoiceWithEmptyCustomer()
        {
            _fixture.SetNullCustomer();
            var mockService = new Mock<IInvoiceService>();
            mockService.Setup(serv => serv.InsertOneAsync(_fixture.Invoice)).ReturnsAsync(1);
            var invoicesController = new InvoicesController(mockService.Object);
        }
        
        
    }
}

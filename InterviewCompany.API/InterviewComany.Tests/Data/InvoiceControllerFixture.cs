using AutoMapper;
using InterviewCompany.API.Controllers;
using InterviewCompany.Domain;
using InterviewCompany.Domain.Repositories;
using InterviewCompany.Domain.Repositories.Interfaces;
using InterviewCompany.Service;
using InterviewCompany.Service.Mappings;
using InterviewCompany.Service.Tools;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using System.Text;

namespace InterviewCompany.Tests.Data
{
    public class InvoiceControllerFixture
    {
        private readonly IConfigurationRoot _config;
        private readonly IMapper _mapper;
        private readonly MongoDbContext _context;
        private readonly IInvoiceRepository _invoiceRepository;
        private readonly ICurrencyRepository _currencyRepository;
        private readonly IInvoiceService _invoiceService;
        private readonly InvoicesController _invoicesController;
        private readonly InvoiceCalculator _invoiceCalculator;

        public InvoiceControllerFixture()
        {
            var x = Directory.GetCurrentDirectory();
            var y = Environment.CurrentDirectory;
            var z = Assembly.GetExecutingAssembly();

            _config = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                        .AddJsonFile("appsettings.json")
                        .Build();

            var mongoSettings = _config.GetSection("MongoSettings").Get<MongoSettings>();
            var options = Options.Create<MongoSettings>(mongoSettings);
            _context = new MongoDbContext(options);
            _invoiceRepository = new MongoInvoiceRepository(_context);
            _currencyRepository = new MongoCurrencyRepository(_context);
            var mapperConfig = new MapperConfiguration(cfg => cfg.AddProfile(new AddInvoiceMapping()));
            _mapper = new Mapper(mapperConfig);
            _invoiceCalculator = new InvoiceCalculator(_currencyRepository);
            _invoiceService = new InvoiceService(_invoiceRepository, _currencyRepository, _mapper, _invoiceCalculator);
            _invoicesController = new InvoicesController(_invoiceService);
        }

        public InvoicesController Controller
        {
            get { return _invoicesController; }
        }
    }
}

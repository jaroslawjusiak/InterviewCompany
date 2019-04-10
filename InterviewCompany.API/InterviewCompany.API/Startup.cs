using AutoMapper;
using InterviewCompany.Domain;
using InterviewCompany.Domain.Repositories;
using InterviewCompany.Domain.Repositories.Interfaces;
using InterviewCompany.Service;
using InterviewCompany.Service.Tools;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using MongoDB.Driver;
using Swashbuckle.AspNetCore.Swagger;
using System;
using System.IO;
using System.Reflection;

namespace InterviewCompany.API
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2);
            services.Configure<MongoSettings>(options =>
            {
                options.ConnectionString
                    = Configuration.GetSection("MongoSettings:ConnectionString").Value;
                options.Database
                    = Configuration.GetSection("MongoSettings:Database").Value;
            });
            services.AddSingleton(new MongoClient(Configuration.GetSection("MongoSettings:ConnectionString").Value));

            services.AddAutoMapper();

            services.AddScoped<IInvoiceRepository, MongoInvoiceRepository>();
            services.AddScoped<MongoDbContext>();
            services.AddScoped<ICurrencyRepository, MongoCurrencyRepository>();
            services.AddScoped<InvoiceCalculator>();
            services.AddScoped<IInvoiceService, InvoiceService>();
            services.AddScoped<CurrencyService>();

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new Info
                {
                    Version = "v1",
                    Title = "Interview Company API",
                    Description = "Interview project - Invoice with diffrent currencies",
                    TermsOfService = "TODO",
                    Contact = new Contact
                    {
                        Name = "Jarosław Jusiak",
                        Email = "jaroslaw.jusiak@britenet.com.pl",
                        Url = "https://britenet.com.pl"
                    },
                    License = new License
                    {
                        Name = "TODO",
                        Url = "TODO"
                    }
                });
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }
            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "Interview Company API v1");
            });
            app.UseHttpsRedirection();
            app.UseMvc();
        }
    }
}

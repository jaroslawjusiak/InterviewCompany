using AutoMapper;
using InterviewCompany.Domain.Documents;
using InterviewCompany.Domain.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace InterviewCompany.Service.Mappings
{
    public class AddInvoiceMapping : Profile
    {
        public AddInvoiceMapping()
        {
            CreateMap<AddInvoiceModel, Invoice>()
                .ForMember(i => i.BillTo, opt => opt.MapFrom(model => model.BillTo))
                .ForMember(i => i.IssueDate, opt => opt.MapFrom(src => DateTime.Now))
                .ForMember(i => i.Id, opt => opt.MapFrom(src => Guid.NewGuid()))
                .ForMember(i => i.Issuer, opt => opt.MapFrom(model => model.Issuer))
                .ForMember(i => i.Items, opt => opt.MapFrom(model => model.Items));
        }
    }
}

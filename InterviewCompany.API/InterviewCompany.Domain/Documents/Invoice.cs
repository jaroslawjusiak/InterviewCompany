﻿using InterviewCompany.Domain.Model;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;

namespace InterviewCompany.Domain.Documents
{
    [BsonIgnoreExtraElements]
    public class Invoice
    {
        [BsonId]
        [BsonRepresentation(BsonType.String)]
        public Guid Id { get; set; }
        public int Number { get; set; }
        public DateTime IssueDate { get; set; }
        public Customer BillTo { get; set; }
        public Customer Issuer { get; set; }
        public InvoiceItem[] Items { get; set; }
        public decimal TotalAmount { get; set; }
    }
}

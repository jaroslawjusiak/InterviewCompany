using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Text;

namespace InterviewCompany.Domain.Documents
{
    public class Invoice
    {
        [BsonId]
        [BsonRepresentation(BsonType.String)]
        public Guid Id { get; set; }
        public int Number { get; set; }
        public DateTime IssueDate { get; set; }
        public Customer Customer { get; set; }
        public decimal TotalAmount { get; set; }
    }
}

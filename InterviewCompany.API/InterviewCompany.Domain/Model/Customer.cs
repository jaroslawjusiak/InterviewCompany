using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace InterviewCompany.Domain.Model
{
    public class Customer
    {
        [Required(AllowEmptyStrings = false)]
        public string Name { get; set; }
        public string Street { get; set; }

        [Required(AllowEmptyStrings = false)]
        public string City { get; set; }
        public string State { get; set; }
        public string Country { get; set; }
        public string ZIPCode { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
    }
}

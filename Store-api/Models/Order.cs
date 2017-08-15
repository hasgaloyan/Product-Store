using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;

namespace ProductStoreAPI.Models
{
    public class Order
    {
        [Key]
        public long ID { get; set; }
        //public List<OrderItem> OrderItems { get; set; }

        //Required fields
        [Required]
        public string FirstName { get; set; }
        [Required]
        public string LastName { get; set; }
        [Required]
        public string Address { get; set; }
        [Required]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        //Optional fields
        [DataType(DataType.DateTime)]
        public string OrderDate { get; set; }

        [DataType(DataType.PhoneNumber)]
        public string Phone { get; set; }

        [DataType(DataType.PostalCode)]
        public string PostalCode { get; set; }

        public string City { get; set; }
        public string Country { get; set; }
        public string State { get; set; }
        public string Username { get; set; }

        public decimal Total
        {
            get; set;
        }
    }
}



using System;
using System.ComponentModel.DataAnnotations;

namespace ProductStoreAPI.Models
{
    public class OrderItem
    {
        [Key]
        public long ID { get; set; }

        public string UID { get; set; }

        public long OrderID { get; set; }

        public long ProductID { get; set; }
        public Product Product { get; set; }

        public int Quantity { get; set; }
    }
}
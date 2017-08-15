using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ProductStoreAPI.Models
{
    public class Category
    {
        [Key]
        public int ID { get; set; }
        [Required]
        public string Name { get; set; }

        public List<Product> Products { get; set; }
    }
}

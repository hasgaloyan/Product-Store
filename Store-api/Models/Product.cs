using System;
using System.ComponentModel.DataAnnotations;


namespace ProductStoreAPI.Models
{
    public class Product
    {
        [Key]
        public long ID { get; set; }
        [MaxLength(80)]
        public string Name { get; set; }

        public int CategoryID { get; set; }
        public Category Category { get; set; }

        [MaxLength(200)]
        public string Description { get; set; }
        [DataType(DataType.Url)]
        public string Url { get; set; }
        public int Price { get; set; }

        public override string ToString()
        {
            return string.Format("[Product: ID={0}, Name={1}, CategoryID={2}, Category={3}, Description={4}, Url={5}, Price={6}]", ID, Name, CategoryID, Category, Description, Url, Price);
        }
    }
}
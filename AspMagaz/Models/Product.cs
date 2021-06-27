using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace AspMagaz.Models
{
    [Table("Products")]
    public abstract class Product
    {
        public int Id { private set; get; }
        
        public string Name { set; get; }
        public string Description { set; get; }
        [Column(TypeName = "numeric(18,2)")]
        public decimal Price { set; get; }

        //public int CategoryId { get; set; }
        public Category Category { get; set; }

        public Product() { }
        public Product(string Name, string Description, decimal Price, Category Category)
        {
            this.Name = Name;
            this.Description = Description;
            this.Price = Price;
            this.Category = Category;
            //CategoryId = Category.Id;
        }

        protected static string ConvertMemoryToBigBytes(int memory) 
            => memory switch
            {
                >= 1_048_576 => $"{(double)memory / 1_048_576} TB",
                < 1_048_576 and >= 1024 => $"{(double)memory / 1024} GB",
                < 1024 => $"{memory} MB"
            };

        public abstract IDictionary<string, object> GetCharacteristics();
    }
}

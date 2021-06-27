using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace AspMagaz.Models
{
    public class User
    {
        public int Id { private set; get; }

        public string Name { set; get; }
        public string Surname { set; get; }
        public string Email { get; set; }
        public string Password { get; set; }

        [NotMapped]
        public IDictionary<Product, int> Basket { get; set; }
        public User()
        {
            Basket = new Dictionary<Product, int>();
        }
    }
}

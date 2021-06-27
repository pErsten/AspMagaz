using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace AspMagaz.Models
{
    public class Order
    {
        public int Id { private set; get; }

        //public int UserId { get; set; }
        private User user;
        public User User
        {
            get => user;
            set
            {
                user = value;
                TotalPrice = user.Basket.Sum(x => x.Key.Price * x.Value);
                Products = "{" + user.Basket.Select(x => $"\"{x.Key}\":\"{x.Value}\"").Aggregate((x, y) => $"{x},{y}") + "}";
            }
        }

        public DateTime OrderTime { get; private set; }
        [Column(TypeName="numeric(18,2)")]
        public decimal TotalPrice { get; private set; }
        public string Products { get; private set; }

        public Order()
        {
            OrderTime = DateTime.Now;
        }
    }
}

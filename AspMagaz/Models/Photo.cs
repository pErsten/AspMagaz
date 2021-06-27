using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace AspMagaz.Models
{
    public class Photo
    {
        public int Id { private set; get; }

        [Column(TypeName="varbinary(max)")]
        public byte[] Image { set; get; }
        public bool IsPrimary { get; set; }

        //public int ProductId { set; get; }
        public Product Product { get; set; }

        public Photo() { }
        public Photo(byte[] Image, Product Product, bool IsPrimary = false)
        {
            this.Image = Image;
            this.Product = Product;
            //ProductId = Product.Id;
            this.IsPrimary = IsPrimary;
        }
    }
}

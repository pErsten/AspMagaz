using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AspMagaz.Models
{
    public class Category
    {
        public int Id { get; private set; }

        public string Name { get; set; }
        public string IconUrl { get; set; }
    }
}

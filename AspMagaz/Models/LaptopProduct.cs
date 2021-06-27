using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace AspMagaz.Models
{
    [Table("Laptops")]
    public class LaptopProduct: Product
    {
        /// <summary>
        /// measured in inches
        /// </summary>
        public double ScreenDiagonal { get; set; }
        /// <summary>
        /// measured in megabytes (1024)
        /// </summary>
        public int RAM { get; set; }
        public string RAMtype { get; set; }
        /// <summary>
        /// measured in megabytes (1024)
        /// </summary>
        public int DataStorage { get; set; }

        public int ScreenResolutionWidth { get; set; }
        public int ScreenResolutionHeight { get; set; }

        public string Processor { get; set; }

        public LaptopProduct() : base() { }
        public LaptopProduct(string Name, 
                             string Description, 
                             decimal Price, 
                             Category Category, 
                             double ScreenDiagonal, 
                             int RAM,
                             string RAMtype,
                             int DataStorage, 
                             (int, int) ScreenResolution,
                             string Processor)
            : base(Name, Description, Price, Category)
        {
            this.ScreenDiagonal = ScreenDiagonal;
            this.RAM = RAM;
            this.RAMtype = RAMtype;
            this.DataStorage = DataStorage;
            (ScreenResolutionWidth, ScreenResolutionHeight) = ScreenResolution;
            this.Processor = Processor;
        }

        public override IDictionary<string, object> GetCharacteristics()
        {
            var Characteristics = new Dictionary<string, object>();
            Characteristics["Type of RAM"] = RAMtype;
            Characteristics["RAM memory"] = ConvertMemoryToBigBytes(RAM);
            Characteristics["Inner storage"] = ConvertMemoryToBigBytes(DataStorage);
            Characteristics["Screen diagonal"] = ScreenDiagonal;
            Characteristics["Screen resolution"] = $"{ScreenResolutionWidth}x{ScreenResolutionHeight}";
            Characteristics["Processor"] = Processor;
            Characteristics["PPI"] = Math.Floor(Math.Sqrt(ScreenResolutionHeight * ScreenResolutionHeight + ScreenResolutionWidth * ScreenResolutionWidth) / ScreenDiagonal);

            return Characteristics;
        }
    }
}

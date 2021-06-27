using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace AspMagaz.Models
{
    [Table("Smartphones")]
    public class SmartphoneProduct: Product
    {
        /// <summary>
        /// measured in inches
        /// </summary>
        public double ScreenDiagonal { get; set; }
        /// <summary>
        /// measured in megabytes (1024)
        /// </summary>
        public int RAM { get; set; }
        /// <summary>
        /// measured in megabytes (1024)
        /// </summary>
        public int DataStorage { get; set; }

        public int ScreenResolutionWidth { get; set; }
        public int ScreenResolutionHeight { get; set; }

        public SmartphoneProduct() : base() { }
        public SmartphoneProduct(string Name, 
                                 string Description, 
                                 decimal Price, 
                                 Category Category, 
                                 double ScreenDiagonal, 
                                 int RAM, 
                                 int DataStorage, 
                                 (int, int) ScreenResolution)
            : base(Name, Description, Price, Category)
        {
            this.ScreenDiagonal = ScreenDiagonal;
            this.RAM = RAM;
            this.DataStorage = DataStorage;
            (ScreenResolutionWidth, ScreenResolutionHeight) = ScreenResolution;
        }

        public override IDictionary<string, object> GetCharacteristics()
        {
            var Characteristics = new Dictionary<string, object>();
            Characteristics["RAM memory"] = ConvertMemoryToBigBytes(RAM);
            Characteristics["Inner storage"] = ConvertMemoryToBigBytes(DataStorage);
            Characteristics["Screen diagonal"] = ScreenDiagonal;
            Characteristics["Screen resolution"] = $"{ScreenResolutionWidth}x{ScreenResolutionHeight}";
            Characteristics["PPI"] = Math.Floor(Math.Sqrt(ScreenResolutionHeight * ScreenResolutionHeight + ScreenResolutionWidth * ScreenResolutionWidth) / ScreenDiagonal);

            return Characteristics;
        }
    }
}

using AspMagaz.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace AspMagaz
{
    public class StartData
    {
        public static void InitializeData(MagazContext context)
        {
            if (!context.Categories.Any())
                CategoriesInit(context);
            if (!context.Products.Any())
                ProductsInit(context);
            if (!context.Photoes.Any())
                PhotoesInit(context);
        }
        private static void CategoriesInit(MagazContext context)
        {
            context.Categories.AddRange(
                new Category { Name = "Smartphones", IconUrl= @"https://image.flaticon.com/icons/png/128/254/254638.png" },
                new Category { Name = "Laptops", IconUrl= @"https://image.flaticon.com/icons/png/128/254/254629.png" }
                );
            context.SaveChanges();
        }
        private static void ProductsInit(MagazContext context)
        {
            var LaptopCategory = context.Categories.First(x => x.Name == "Laptops");
            context.LaptopProducts.AddRange(
                new LaptopProduct("Acer Aspire 5 A515-56G-54JD (NX.A1LEU.00A) Pure Silver", null, 19_999M, LaptopCategory, 15.6, 8 << 10, "DDR4", 512 << 10, (1920, 1080), "QuadCore Intel Core i5-1135G7 4200 MHz"),
                new LaptopProduct("Apple MacBook Air 13\" M1 256GB 2020(MGND3) Gold", null, 33_999M, LaptopCategory, 13.3, 8 << 10, null, 256 << 10, (2560, 1600), "8 core Apple M1"),
                new LaptopProduct("Lenovo ThinkPad X1 Carbon (7th Gen) (20QESCNN00) Black", null, 33_333M, LaptopCategory, 14.0, 16 << 10, "LPDDR3-2133 MHz", 512 << 10, (1920, 1080), "QuadCore Intel Core i5-8365U 1600-4100 MHz")
                );
            var SmartphoneCategory = context.Categories.First(x => x.Name == "Smartphones");
            context.SmartphoneProducts.AddRange(
                new SmartphoneProduct("Samsung Galaxy A71 6/128GB Black (SM-A715FZKUSEK)", null, 10_799M, SmartphoneCategory, 6.7, 6 << 10, 128 << 10, (2400, 1080)),
                new SmartphoneProduct("Nokia 3.4 3/64GB Fjord", null, 3_499M, SmartphoneCategory, 6.39, 3 << 10, 64 << 10, (1560, 720)),
                new SmartphoneProduct("Apple iPhone SE 64GB 2020 White Slim Box (MHGQ3)", null, 14_599M, SmartphoneCategory, 4.7, 3 << 10, 64 << 10, (1334,750))
                );
            context.SaveChanges();
        }
        private static void PhotoesInit(MagazContext context)
        {
            var AcerLaptop = context.LaptopProducts.First(x => x.Name == "Acer Aspire 5 A515-56G-54JD (NX.A1LEU.00A) Pure Silver");
            context.Photoes.AddRange(
                new Photo(ImageToByteArray(@"https://content.rozetka.com.ua/goods/images/big/37871265.jpg"), AcerLaptop, true),
                new Photo(ImageToByteArray(@"https://content.rozetka.com.ua/goods/images/big/37871275.jpg"), AcerLaptop),
                new Photo(ImageToByteArray(@"https://content.rozetka.com.ua/goods/images/big/37871286.jpg"), AcerLaptop),
                new Photo(ImageToByteArray(@"https://content.rozetka.com.ua/goods/images/big/37871302.jpg"), AcerLaptop),
                new Photo(ImageToByteArray(@"https://content.rozetka.com.ua/goods/images/big/37871235.jpg"), AcerLaptop),
                new Photo(ImageToByteArray(@"https://content.rozetka.com.ua/goods/images/big/37871243.jpg"), AcerLaptop),
                new Photo(ImageToByteArray(@"https://content.rozetka.com.ua/goods/images/big/37871256.jpg"), AcerLaptop),
                new Photo(ImageToByteArray(@"https://content.rozetka.com.ua/goods/images/big/37871261.jpg"), AcerLaptop)
                );
            var AppleLaptop = context.LaptopProducts.First(x => x.Name == "Apple MacBook Air 13\" M1 256GB 2020(MGND3) Gold");
            context.Photoes.AddRange(
                new Photo(ImageToByteArray(@"https://content.rozetka.com.ua/goods/images/big/30872664.jpg"), AppleLaptop, true),
                new Photo(ImageToByteArray(@"https://content.rozetka.com.ua/goods/images/big/30872671.jpg"), AppleLaptop),
                new Photo(ImageToByteArray(@"https://content.rozetka.com.ua/goods/images/big/30872676.jpg"), AppleLaptop),
                new Photo(ImageToByteArray(@"https://content.rozetka.com.ua/goods/images/big/30872706.jpg"), AppleLaptop),
                new Photo(ImageToByteArray(@"https://content.rozetka.com.ua/goods/images/big/30872684.jpg"), AppleLaptop),
                new Photo(ImageToByteArray(@"https://content.rozetka.com.ua/goods/images/big/30872694.jpg"), AppleLaptop)
                );
            var LenovoLaptop = context.LaptopProducts.First(x => x.Name == "Lenovo ThinkPad X1 Carbon (7th Gen) (20QESCNN00) Black");
            context.Photoes.AddRange(
                new Photo(ImageToByteArray(@"https://content.rozetka.com.ua/goods/images/big/75254690.jpg"), LenovoLaptop, true),
                new Photo(ImageToByteArray(@"https://content1.rozetka.com.ua/goods/images/big/180803645.jpg"), LenovoLaptop),
                new Photo(ImageToByteArray(@"https://content1.rozetka.com.ua/goods/images/big/180803646.jpg"), LenovoLaptop),
                new Photo(ImageToByteArray(@"https://content2.rozetka.com.ua/goods/images/big/180803647.jpg"), LenovoLaptop),
                new Photo(ImageToByteArray(@"https://content1.rozetka.com.ua/goods/images/big/180803648.jpg"), LenovoLaptop),
                new Photo(ImageToByteArray(@"https://content2.rozetka.com.ua/goods/images/big/180803649.jpg"), LenovoLaptop),
                new Photo(ImageToByteArray(@"https://content1.rozetka.com.ua/goods/images/big/180803650.jpg"), LenovoLaptop)
                );
            var SamsungPhone = context.SmartphoneProducts.First(x => x.Name == "Samsung Galaxy A71 6/128GB Black (SM-A715FZKUSEK)");
            context.Photoes.AddRange(
                new Photo(ImageToByteArray(@"https://content.rozetka.com.ua/goods/images/big/21006410.png"), SamsungPhone, true),
                new Photo(ImageToByteArray(@"https://content.rozetka.com.ua/goods/images/big/21006399.png"), SamsungPhone),
                new Photo(ImageToByteArray(@"https://content.rozetka.com.ua/goods/images/big/21006425.png"), SamsungPhone),
                new Photo(ImageToByteArray(@"https://content.rozetka.com.ua/goods/images/big/21006440.png"), SamsungPhone)
                );
            var NokiaPhone = context.SmartphoneProducts.First(x => x.Name == "Nokia 3.4 3/64GB Fjord");
            context.Photoes.AddRange(
                new Photo(ImageToByteArray(@"https://content.rozetka.com.ua/goods/images/big/163017812.png"), NokiaPhone, true),
                new Photo(ImageToByteArray(@"https://content.rozetka.com.ua/goods/images/big/163017815.png"), NokiaPhone),
                new Photo(ImageToByteArray(@"https://content.rozetka.com.ua/goods/images/big/163017821.png"), NokiaPhone),
                new Photo(ImageToByteArray(@"https://content.rozetka.com.ua/goods/images/big/163017823.png"), NokiaPhone)
                );
            var ApplePhone = context.SmartphoneProducts.First(x => x.Name == "Apple iPhone SE 64GB 2020 White Slim Box (MHGQ3)");
            context.Photoes.AddRange(
                new Photo(ImageToByteArray(@"https://content.rozetka.com.ua/goods/images/big/37427546.png"), ApplePhone, true),
                new Photo(ImageToByteArray(@"https://content.rozetka.com.ua/goods/images/big/37427568.jpg"), ApplePhone),
                new Photo(ImageToByteArray(@"https://content.rozetka.com.ua/goods/images/big/37427576.jpg"), ApplePhone),
                new Photo(ImageToByteArray(@"https://content.rozetka.com.ua/goods/images/big/37427591.jpg"), ApplePhone),
                new Photo(ImageToByteArray(@"https://content.rozetka.com.ua/goods/images/big/37427610.jpg"), ApplePhone),
                new Photo(ImageToByteArray(@"https://content.rozetka.com.ua/goods/images/big/37427616.jpg"), ApplePhone),
                new Photo(ImageToByteArray(@"https://content.rozetka.com.ua/goods/images/big/37427620.jpg"), ApplePhone)
                );
            context.SaveChanges();
        }

        private static byte[] ImageToByteArray(string ImageUrl)
        {
            System.Net.WebRequest request = System.Net.WebRequest.Create(ImageUrl);
            System.Net.WebResponse response = request.GetResponse();
            System.IO.Stream responseStream = response.GetResponseStream();
            System.Drawing.Bitmap image = new System.Drawing.Bitmap(responseStream, true);
            var ms = new MemoryStream();
            image.Save(ms, image.RawFormat);
            return ms.ToArray();
        }
    }
}

namespace PointOfSale.Sample
{
    using System;
    using System.Linq;
    using PointOfSale.Contents.Additive.Items;
    using PointOfSale.Contents.Beverage.Infrastructure;
    using PointOfSale.Contents.Beverage.Items.Basic;
    using PointOfSale.Contents.Beverage.Items.Special;
    using PointOfSale.Contents.Common;
    using PointOfSale.Contents.Service;
    using PointOfSale.Gui;

    class Pos
    {
        static void Main(string[] args)
        {
            //啟動Pos系統
            var site = Site.Launch("PoweredByViyrex");

            //現場點餐，綠茶大杯加珍珠，微糖去冰
            //Order方法會返回一個編號用以查詢
            var guest1 = site.Order(BeverageProvider.Context.CreateInstance("GreenTea", Size.Venti, AmountOfIce.Free, SweetnessLevel.Quarter, AdditiveProvider.Context.GetInstanse("Pearl")));
            //顯示guest1的資料
            Console.WriteLine(site[guest1]);
            Console.WriteLine();

            //預約現場取餐，奶茶大杯加椰果，少糖微冰
            var guest2 = site.Order("Yuyu", "0978978778", BeverageProvider.Context.CreateInstance("MilkTea", Size.Venti, AmountOfIce.Easy, SweetnessLevel.Quarter, AdditiveProvider.Context.GetInstanse<CoconutJelly>()));
            //顯示guest2的資料
            Console.WriteLine(site[guest2]);
            Console.WriteLine();

            //外送
            //奶茶大杯加椰果，少糖微冰
            var _1st = BeverageProvider.Context.CreateInstance("MilkTea", Size.Venti, AmountOfIce.Easy, SweetnessLevel.Quarter, AdditiveProvider.Context.GetInstanse<CoconutJelly>());
            //阿華田, 少糖 溫
            var _2nd = BeverageProvider.Context.CreateInstance<Ovaltine>(Size.Grande, AmountOfIce.Free, SweetnessLevel.Quarter, Temperature.Warm);
            //烏龍茶大杯，少糖正常冰
            var _3rd = BeverageProvider.Context.CreateInstance<OolongTea>(Size.Venti, AmountOfIce.Regular, SweetnessLevel.Half, Temperature.Cold);
            //奶茶大杯加布丁、粉條，七分糖半冰
            var _4th = BeverageProvider.Context.CreateInstance("MilkTea", Size.Venti, AmountOfIce.Half, SweetnessLevel.Less, 
                AdditiveProvider.Context.GetInstanse<Pudding>(),
                AdditiveProvider.Context.GetInstanse<RatNoodle>());
            var guest3 = site.Order("Yumiko", "073599999", "火星區青龍路300號769樓之87", _1st, _2nd, _3rd, _4th);
            //顯示guest3的資料
            Console.WriteLine(site[guest3]);
            Console.WriteLine();

            //製作報表
            var report = site.Settlement("PoweredByViyrex");
            
            //添加物排名
            Console.WriteLine("========== {0} ==========", nameof(report.AdditiveRank));
            foreach (var item in report.AdditiveRank
                                        .OrderByDescending(a => a.Value)
                                        .Select(a => new { a.Key.Name, Count = a.Value }))
                Console.WriteLine(item); //顯示排名
            Console.WriteLine();

            //飲料排名
            Console.WriteLine("========== {0} ==========", nameof(report.BeverageRank));
            foreach (var item in report.BeverageRank
                                        .OrderByDescending(a => a.Value)
                                        .Select(a => new { a.Key.Name, Count = a.Value }))
                Console.WriteLine(item);//顯示排名
            Console.WriteLine();

            //日營業收入
            Console.WriteLine($"Revenue: {report.Revenue}"); //顯示日營收

            Console.WriteLine(Enum<AmountOfIce>.Parse("Free").GetType());

            Console.ReadKey();
        }
    }
}

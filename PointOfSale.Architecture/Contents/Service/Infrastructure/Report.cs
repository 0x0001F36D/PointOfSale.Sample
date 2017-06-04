using System;
using System.Collections.Generic;
using System.Linq;
using PointOfSale.Contents.Beverage.Infrastructure;
using PointOfSale.Contents.Common;

namespace PointOfSale.Contents.Service.Infrastructure
{
    public class Report
    {
        public Report(Site site)
        {
            this.orders = new List<OrderType>(site.OfType<OrderType>());
            this.Time = site.LaunchTime.ToShortDateString();
            this.Revenue = this.orders.Sum(o => o.Total);
            this.TotalSold = this.orders.SelectMany(o => o).ToList();

            var k = this.TotalSold.Select(b => b.GetType());
            this.BeverageRank = BeverageProvider.Context.ToDictionary(t => t, t => k.Count(v=> v == t));

            var q = this.TotalSold.SelectMany(b => b.Additives).Select(x => x.GetType());
            this.AdditiveRank = AdditiveProvider.Context.ToDictionary(t => t.Key, t => q.Count(v => v == t.Key));
        }
        private readonly IEnumerable<OrderType> orders;

        public string Time { get; private set; }
        public decimal Revenue { get; private set; }
        public IReadOnlyList<IBeverage> TotalSold { get; private set; }
        public IReadOnlyDictionary<Type, int> BeverageRank { get; private set; }
        public IReadOnlyDictionary<Type, int> AdditiveRank { get; private set; }
    }
}

using System.Linq;
using PointOfSale.Contents.Additive.Infrastructure;
using PointOfSale.Contents.Beverage.Infrastructure;

namespace PointOfSale.Contents.Common
{
    public static class BeverageHelper
    {
        public static IBeverage Append(this IBeverage beverage, params IAdditive[] additive)
            => additive.Aggregate(beverage, (b, a) => b.AppendAdditive(a));

        public static IBeverage Remove(this IBeverage beverage, params IAdditive[] additive)
            => additive.Aggregate(beverage, (b, a) => b.RemoveAdditive(a));

        
    }
}

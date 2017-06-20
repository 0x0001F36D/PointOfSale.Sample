using PointOfSale.Contents.Common;
using System;

namespace PointOfSale.Contents.Beverage.Infrastructure
{
    [Flags]
    [I18NAttribute("溫度")]
    public enum Temperature
    {
        [I18NAttribute("冷")]
        Cold = 1,
        [I18NAttribute("熱")]
        Hot = 2,
        [I18NAttribute("溫")]
        Warm = Cold | Hot,
    }
}

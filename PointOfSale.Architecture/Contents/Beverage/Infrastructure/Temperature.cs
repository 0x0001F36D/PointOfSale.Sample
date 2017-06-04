using System;

namespace PointOfSale.Contents.Beverage.Infrastructure
{
    [Flags]
    public enum Temperature
    {
        Cold = 1,
        Hot = 2,
        Warm = Cold | Hot,
    }
}

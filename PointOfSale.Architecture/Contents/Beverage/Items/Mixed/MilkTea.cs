using System.Collections.Generic;
using PointOfSale.Contents.Additive.Infrastructure;
using PointOfSale.Contents.Beverage.Infrastructure;
using PointOfSale.Contents.Beverage.Items.Basic;

namespace PointOfSale.Contents.Beverage.Items.Mixed
{
    public class MilkTea : BlackTea
    {
        public MilkTea(Temperature temperature, SweetnessLevel sweetnessLevel, AmountOfIce amountOfIce, Size size, IEnumerable<IAdditive> additives = null) : base(temperature, sweetnessLevel, amountOfIce, size, additives)
        {
        }
        public override decimal Price => base.Price + 10;
    }
}

using System.Collections.Generic;
using PointOfSale.Contents.Additive.Infrastructure;
using PointOfSale.Contents.Beverage.Infrastructure;

namespace PointOfSale.Contents.Beverage.Items.Basic
{
    public class GreenTea : BeverageBase
    {
        public GreenTea(Temperature temperature, SweetnessLevel sweetnessLevel, AmountOfIce amountOfIce, Size size, IEnumerable<IAdditive> additives = null) : base(temperature, sweetnessLevel, amountOfIce, size, additives)
        {
        }
    }
}

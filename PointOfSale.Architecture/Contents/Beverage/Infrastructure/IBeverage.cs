using System.Collections.Generic;
using PointOfSale.Contents.Additive.Infrastructure;

namespace PointOfSale.Contents.Beverage.Infrastructure
{
    public interface IBeverage 
    {
        string Name { get; }
        decimal Price { get; }
        Temperature Temperature { get; }
        SweetnessLevel SweetnessLevel { get; }
        AmountOfIce AmountOfIce { get; }
        Size Size { get; }

        IList<IAdditive> Additives { get; }

        void ModifyTemperature(Temperature temperature);
        void ModifySweetnessLevel(SweetnessLevel sweetnessLevel);
        void ModifyAmountOfIce(AmountOfIce amountOfIce);
        void ModifySize(Size size);

        IBeverage AppendAdditive(IAdditive additive);
        IBeverage RemoveAdditive(IAdditive additive);

        string Detail();
    }
}

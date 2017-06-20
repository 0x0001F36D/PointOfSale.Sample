using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using PointOfSale.Contents.Additive.Infrastructure;
using PointOfSale.Contents.Common;

namespace PointOfSale.Contents.Beverage.Infrastructure
{
    public abstract class BeverageBase : IBeverage
    {
        protected BeverageBase(Temperature temperature, SweetnessLevel sweetnessLevel, AmountOfIce amountOfIce, Size size, IEnumerable<IAdditive> additives = null)
        {
            this.SweetnessLevel = sweetnessLevel;
            this.Temperature = temperature;
            this.Size = size;
            this.AmountOfIce = amountOfIce;
            this.Additives = additives == null ? new List<IAdditive>() : new List<IAdditive>(additives);
        }

        internal const decimal BasicBeveragePrice = 15;

        public virtual string Name => this.GetType().Name;

        public virtual decimal Price => BasicBeveragePrice + (decimal)this.Size + this.Additives?.Sum(x => x.Price) ?? 0;

        public Temperature Temperature { get; private set; }

        public SweetnessLevel SweetnessLevel { get; private set; }

        public AmountOfIce AmountOfIce
        {
            get
            {
                if (this.Temperature != Temperature.Cold)
                    return this.amountOfIce = AmountOfIce.Free;
                return this.amountOfIce;
            }
            private set
                => this.amountOfIce = (this.Temperature != Temperature.Cold) ? AmountOfIce.Free : value;
        }
        private AmountOfIce amountOfIce;

        public Size Size { get; private set; }

        public IList<IAdditive> Additives { get; private set; }

        public void ModifyTemperature(Temperature temperature)
            => this.Temperature = Temperature;

        public void ModifySweetnessLevel(SweetnessLevel sweetnessLevel)
            => this.SweetnessLevel = SweetnessLevel;

        public void ModifyAmountOfIce(AmountOfIce amountOfIce)
            => this.AmountOfIce = AmountOfIce;

        public void ModifySize(Size size)
            => this.Size = Size;

        public IBeverage AppendAdditive(IAdditive additive)
        {
            this.Additives?.Add(additive);
            return this;
        }

        public IBeverage RemoveAdditive(IAdditive additive)
        {
            this.Additives?.Remove(additive);
            return this;
        }

        public virtual string Detail()
            => $"Name: {this.Name}, Additives: {string.Join(", ", this.Additives.Select(a => a?.Name))}, Price: {this.Price}";

    }
}

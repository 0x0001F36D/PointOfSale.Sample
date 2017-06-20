using PointOfSale.Contents.Beverage.Infrastructure;
using PointOfSale.Contents.Common;
using System.Collections.Generic;
using System.Windows.Forms;

namespace PointOfSale.Gui
{
    public class Warpper
    {
        public string Beverage { get; set; }
        public IEnumerable<string> Additives { get; set; }
        public AmountOfIce AmountOfIce { get; set; }
        public Temperature Temperature { get; set; }
        public SweetnessLevel SweetnessLevel { get; set; }
        public new Size Size { get; set; }

        public IBeverage Generate()
            => BeverageProvider.Context.CreateInstance(this.Beverage, this.AmountOfIce, this.Temperature, this.SweetnessLevel, this.Size, this.Additives);
    }
}

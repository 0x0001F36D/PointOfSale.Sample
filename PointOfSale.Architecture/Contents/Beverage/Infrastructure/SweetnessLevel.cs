using PointOfSale.Contents.Common;

namespace PointOfSale.Contents.Beverage.Infrastructure
{
    [I18NAttribute("糖分")]
    public enum SweetnessLevel
    {
        [I18NAttribute("正常糖")]
        Regular = 10,
        [I18NAttribute("少糖")]
        Less = 7,
        [I18NAttribute("半糖")]
        Half = 5,
        [I18NAttribute("微糖")]
        Quarter = 3,
        [I18NAttribute("無糖")]
        Free = 0
    }

}

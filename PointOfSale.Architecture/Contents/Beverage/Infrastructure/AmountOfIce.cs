using PointOfSale.Contents.Common;

namespace PointOfSale.Contents.Beverage.Infrastructure
{
    [I18NAttribute("冰量")]
    public enum AmountOfIce
    {
        [I18NAttribute("正常冰")]
        Regular = 5,
        [I18NAttribute("少冰")]
        Half = 3,
        [I18NAttribute("微冰")]
        Easy = 2,
        [I18NAttribute("去冰")]
        Free = 0
    }
}

using PointOfSale.Contents.Common;

namespace PointOfSale.Contents.Beverage.Infrastructure
{
    [I18NAttribute("容量")]
    public enum Size : int
    {
#if !Not_Supported_Tall
        [I18NAttribute("小杯")]
        Tall = 0,
#endif
        [I18NAttribute("中杯")]
        Grande = 5,

        [I18NAttribute("大杯")]
        Venti = 10
    }
}

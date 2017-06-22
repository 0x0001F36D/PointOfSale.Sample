using PointOfSale.Contents.Common;

namespace PointOfSale.Contents.Beverage.Infrastructure
{
    public enum Size : int
    {
#if !Not_Supported_Tall
        Tall = 0,
#endif
        Grande = 5,
        
        Venti = 10
    }
}

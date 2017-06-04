using PointOfSale.Contents.Service.Infrastructure;

namespace PointOfSale.Contents.Service.Common
{
    /// <summary>
    /// 現場
    /// </summary>
    public sealed class Takeaway : OrderType
    {
        public Takeaway(int id) : base(id, Guest.Undefined)
        {
        }
    }
}

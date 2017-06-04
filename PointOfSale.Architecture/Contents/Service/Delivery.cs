using PointOfSale.Contents.Service.Infrastructure;

namespace PointOfSale.Contents.Service
{
    /// <summary>
    /// 外送
    /// </summary>
    public sealed class Delivery : OrderType
    {
        public Delivery(int id, string name, string phoneNumber , string address) : base(id, new Guest(name, phoneNumber, address))
        {
        }
    }
}

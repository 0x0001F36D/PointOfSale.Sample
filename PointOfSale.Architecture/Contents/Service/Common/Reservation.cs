using PointOfSale.Contents.Service.Infrastructure;

namespace PointOfSale.Contents.Service.Common
{
    /// <summary>
    /// 電話預約
    /// </summary>
    public sealed class Reservation : OrderType
    {
        public Reservation(int id, string name, string phoneNumber) : base(id,new Guest(name, phoneNumber, null))
        {
        }
        
    }
}

using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using PointOfSale.Contents.Beverage.Infrastructure;
using PointOfSale.Contents.Common;
using PointOfSale.Contents.Service.Infrastructure;

namespace PointOfSale.Contents.Service
{
    public class Site : IReadOnlyList<OrderType> , ILookup<Guest,IBeverage>
    {
        public static Site Launch(string password)
        {
            try
            {
                return new Site(password);
            }
            catch(Exception e)
            {
                throw e;
            }
        }
        private Site(string password)
        {
            if (this.Verify(password))
            {
                this.launchTime = DateTime.Now;
                this.list = new List<OrderType>();
                this.password = password;
            }
            else
                throw new PosException("Can not launch POS system \nError : password error");
            
        }

        private bool Verify(string password)
        {
            //To do: 驗證密碼

            
            return true;
        }

        private readonly List<OrderType> list;
        
        /// <summary>
        /// 銷售量
        /// </summary>
        public int SellingVolume => this.list.Count;
        private readonly DateTime launchTime;
        private readonly string password;

        /// <summary>
        /// 起動時間
        /// </summary>
        public DateTime LaunchTime => this.launchTime; 

        /// <summary>
        /// 外送服務
        /// </summary>
        public int Order(string name, string phoneNumber, string address, IBeverage beverage, params IBeverage[] beverages)
            => this.Order(name, phoneNumber, address, new[] { beverage }.Concat(beverages));

        /// <summary>
        /// 外送服務
        /// </summary>
        public int Order(string name, string phoneNumber, string address, IEnumerable<IBeverage> beverages)
        {
            var x = beverages.Aggregate(new Delivery(this.SellingVolume + 1, name, phoneNumber, address) as OrderType, (d, o) => d.Order(o));
            this.list.Add(x);
            return this.SellingVolume;
        }
        
        /// <summary>
        /// 現場點餐取餐
        /// </summary>
        public int Order(IBeverage beverage, params IBeverage[] beverages)
            => this.Order(new[] { beverage }.Concat(beverages));

        /// <summary>
        /// 現場點餐取餐
        /// </summary>
        public int Order(IEnumerable<IBeverage> beverages)
        {
            var x = beverages.Aggregate(new Takeaway(this.SellingVolume + 1) as OrderType, (d, o) => d.Order(o));
            this.list.Add(x);
            return this.SellingVolume;
        }

        /// <summary>
        /// 電話預約，現場取餐
        /// </summary>
        public int  Order(string name, string phoneNumber, IBeverage beverage, params IBeverage[] beverages)
            => this.Order(name, phoneNumber, new[] { beverage }.Concat(beverages));

        /// <summary>
        /// 電話預約，現場取餐
        /// </summary>
        public int Order(string name, string phoneNumber, IEnumerable<IBeverage> beverages)
        {
            var x = beverages.Aggregate(new Reservation(this.SellingVolume + 1, name, phoneNumber) as OrderType, (d, o) => d.Order(o));
            this.list.Add(x);
            return this.SellingVolume;
        }
        
        /// <summary>
        /// 取消點餐
        /// </summary>
        /// <param name="id"></param>
        public void Cancel(int id)
            => this.list[id] = null;
        
        /// <summary>
        /// 結算
        /// </summary>
        /// <param name="password"></param>
        public Report Settlement(string password)
        {
            if (!password.Equals(this.password))
                throw new PosException("Password Error !");

            return new Report(this);

        }



        public OrderType this[int id] => this.list[id-1];

        public int Count => this.list.Count;

        public IEnumerator<OrderType> GetEnumerator() 
            => this.list.GetEnumerator();

        IEnumerator IEnumerable.GetEnumerator() 
            => this.GetEnumerator();

        public bool Contains(Guest key) 
            => this.list.Find(o => o.Guest.Equals(key)) != null;

        public IEnumerable<IBeverage> this[Guest key] 
            => this.list.Find(o => o.Guest.Equals(key)).AsEnumerable();

        IEnumerator<IGrouping<Guest, IBeverage>> IEnumerable<IGrouping<Guest, IBeverage>>.GetEnumerator()
            => this.list.GetEnumerator();
        
    }
}

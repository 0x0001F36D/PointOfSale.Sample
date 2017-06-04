using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using PointOfSale.Contents.Beverage.Infrastructure;

namespace PointOfSale.Contents.Service.Infrastructure
{
    public abstract class OrderType : IGrouping<Guest, IBeverage>
    {
        protected OrderType(int id, Guest guest)
        {
            this.OrderTime = DateTime.Now;
            this.Id = id;
            this.Guest = guest;
            this.beverages = new List<IBeverage>();
        }

        public string OrderForm => this.GetType().Name;
        
        public readonly DateTime OrderTime;

        private readonly List<IBeverage> beverages;

        public int Id { get; private set; }

        public OrderType Order(IBeverage beverage)
        {
            this.beverages.Add(beverage);
            return this;
        }

        public OrderType Cancel(IBeverage beverage)
        {
            this.beverages.Remove(beverage);
            return this;
        }

        public override bool Equals(object obj)
            => (obj is OrderType x) ? x.GetHashCode() == this.GetHashCode() : false;

        public override int GetHashCode()
            => this.Id;

        public override string ToString()
            => $"[{this.OrderTime.ToString()}, {this.OrderForm}] " + Environment.NewLine +
                this.Guest?.ToString() + Environment.NewLine +
                String.Join(Environment.NewLine, this.beverages.Select(x => x.Detail()));

        public List<IBeverage> List => this.beverages;

        public Guest Guest { get; private  set; }

        public decimal Total => this.beverages.Sum(x => x.Price);
        
        public IEnumerator<IBeverage> GetEnumerator() 
            => this.beverages.GetEnumerator();

        IEnumerator IEnumerable.GetEnumerator() 
            => this.GetEnumerator();

        Guest IGrouping<Guest, IBeverage>.Key => this.Guest;

        IEnumerator<IBeverage> IEnumerable<IBeverage>.GetEnumerator() 
            => this.GetEnumerator();

    }
}

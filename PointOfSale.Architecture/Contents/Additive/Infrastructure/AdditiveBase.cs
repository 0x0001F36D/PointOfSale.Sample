namespace PointOfSale.Contents.Additive.Infrastructure
{
    public abstract class AdditiveBase : IAdditive
    {
        internal const decimal BasicAdditivePrice = 5;

        public virtual string Name => this.GetType().Name;

        public virtual decimal Price => BasicAdditivePrice;

        public bool Equals(IAdditive other)
            => this.GetHashCode() == other.GetHashCode();

        public override bool Equals(object obj)
            => obj is IAdditive o ? this.GetHashCode() == o.GetHashCode() : false;

        public override int GetHashCode()
            => this.Name.GetHashCode() + this.Price.GetHashCode() << 10;

        protected AdditiveBase()
        {

        }
    }
}

using System;

namespace PointOfSale.Contents.Additive.Infrastructure
{
    public interface IAdditive : IEquatable<IAdditive>
    {
        string Name { get; }

        decimal Price { get; }
    }
}

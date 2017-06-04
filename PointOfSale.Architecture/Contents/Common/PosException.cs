using System;

namespace PointOfSale.Contents.Common
{
    public class PosException : Exception
    {
        public PosException(string message) : base(message) { }
    }
}

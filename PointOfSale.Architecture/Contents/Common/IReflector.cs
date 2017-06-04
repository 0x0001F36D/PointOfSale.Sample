namespace PointOfSale.Contents.Common
{
    public interface IReflector<TTarget>
    {
        TTarget GetInstanse(string name, params object[] args);
        TTarget GetInstanse<TDerivative>(params object[] args) where TDerivative : TTarget;
    }
}
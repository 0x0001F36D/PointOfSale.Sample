using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using PointOfSale.Contents.Additive.Infrastructure;
using PointOfSale.Contents.Beverage.Infrastructure;

namespace PointOfSale.Contents.Common
{
    public class BeverageProvider : IReadOnlyList<Type>
    {

        #region Singleton
        public static BeverageProvider Context
        {
            get
            {
                if (instance == null)
                    lock (locker)
                        if (instance == null)
                            instance = new BeverageProvider();
                return instance;
            }
        }
        private static BeverageProvider instance;
        private static object locker = new object();
        #endregion

        private BeverageProvider()
            => this.list = AppDomain.CurrentDomain
                        .GetAssemblies()
                        .SelectMany(asm => asm.GetTypes())
                        .Where(t => t.GetInterfaces()
                            .Any(v => v == typeof(IBeverage) & !t.IsAbstract))
                        .ToList();

        private readonly List<Type> list;

        public Type this[int index] => this.list[index];

        public int Count => this.list.Count;

        public IEnumerator<Type> GetEnumerator() 
            => this.list.GetEnumerator();

        IEnumerator IEnumerable.GetEnumerator() 
            => this.list.GetEnumerator();

        public IBeverage CreateInstance(string name, params object[] args)
        {
            var array = new object[]
            {
                default(Temperature),
                default(SweetnessLevel),
                default(AmountOfIce),
                default(Size),
                new List<IAdditive>() as IEnumerable<IAdditive>
            };
            foreach (var item in args)
                switch (item)
                {
                    case Temperature t: array[0] = t; break;
                    case SweetnessLevel sl: array[1] = sl; break;
                    case AmountOfIce aoi: array[2] = aoi; break;
                    case Size s: array[3] = s; break;
                    case IEnumerable<IAdditive> a: (array[4] as List<IAdditive>).AddRange(a); break;
                    case IAdditive a: (array[4] as List<IAdditive>).Add(a); break;
                    case null: break;
                    default:
                        throw new PosException("Not supported this value : " + item);
                }
            return this.list
           .FirstOrDefault(t => t.Name == name)
           .GetConstructor(array.Select(o => o.GetType()).ToArray())
           .Invoke(array) as IBeverage;
        }

        public IBeverage CreateInstance<TBeverage>(params object[] args) where TBeverage : IBeverage
            => this.CreateInstance(typeof(TBeverage).Name);
    }
}

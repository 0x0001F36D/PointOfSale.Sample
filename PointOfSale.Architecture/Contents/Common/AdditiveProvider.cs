using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using PointOfSale.Contents.Additive.Infrastructure;
using PointOfSale.Contents.Beverage.Infrastructure;

namespace PointOfSale.Contents.Common
{
    public class AdditiveProvider : IReadOnlyDictionary<Type, IAdditive>
    {
        /*
         * 享元模式 + 單例模式 + 代理模式
         */

        #region Singleton
        public static AdditiveProvider Context
        {
            get
            {
                if (instance == null)
                    lock (locker)
                        if (instance == null)
                            instance = new AdditiveProvider();
                return instance;
            }
        }
        private static AdditiveProvider instance;
        private static object locker = new object();
        #endregion

        private AdditiveProvider()
            => this.dict = AppDomain.CurrentDomain
                        .GetAssemblies()
                        .SelectMany(asm => asm.GetTypes())
                        .Where(t => t.GetInterfaces()
                            .Any(v => v == typeof(IAdditive) & !t.IsAbstract))
                        .ToDictionary(t => t, t => t.GetConstructor(Type.EmptyTypes).Invoke(null) as IAdditive);

        public IBeverage Append(IBeverage beverage, params IAdditive[] additive)
            => additive.Aggregate(beverage, (b, a) => b.AppendAdditive(a));

        public IBeverage Remove(IBeverage beverage, params IAdditive[] additive)
            => additive.Aggregate(beverage, (b, a) => b.RemoveAdditive(a));

        public IAdditive GetInstanse(string name)
            => this.FirstOrDefault(x => x.Key.Name.Equals(name)).Value ?? throw new PosException("Type not loaded : " + name);

        public IAdditive GetInstanse<TAdditive>() where TAdditive : IAdditive
            => this.TryGetValue(typeof(TAdditive), out var t) ? t : throw new PosException("Type not loaded : "+typeof(TAdditive));
            
        private readonly Dictionary<Type, IAdditive> dict;

        public bool ContainsKey(Type key) 
            => this.dict.ContainsKey(key);

        public bool TryGetValue(Type key, out IAdditive value) 
            => this.dict.TryGetValue(key, out value);

        public IAdditive this[Type key] => this.dict[key];

        public IEnumerable<Type> Keys => this.dict.Keys;

        public IEnumerable<IAdditive> Values => this.dict.Values;

        public int Count => this.dict.Count;

        public IEnumerator<KeyValuePair<Type, IAdditive>> GetEnumerator() 
            => this.dict.GetEnumerator();

        IEnumerator IEnumerable.GetEnumerator() 
            => this.GetEnumerator();
    }
}

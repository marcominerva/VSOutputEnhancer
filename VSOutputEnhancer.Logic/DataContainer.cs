using System;
using System.Collections.Generic;

namespace Balakin.VSOutputEnhancer.Logic
{
    public class DataContainer
    {
        private readonly IDictionary<Type, object> data = new Dictionary<Type, object>();

        public TData Get<TData>()
            where TData : new()
        {
            var type = typeof(TData);
            if (data.TryGetValue(type, out var existingItem))
            {
                return (TData)existingItem;
            }

            var newItem = new TData();
            data[type] = newItem;
            return newItem;
        }

        public TData Get<TData>(TData fallback)
        {
            var type = typeof(TData);
            return data.TryGetValue(type, out var existingItem) ? (TData)existingItem : fallback;
        }

        public void Set<TData>(TData item)
        {
            data[typeof(TData)] = item;
        }
    }
}

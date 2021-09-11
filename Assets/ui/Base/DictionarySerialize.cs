using System;
using System.Collections.Generic;

namespace UI.Base
{
    [Serializable]
    public class DictionarySerialize<TKey, TValue>
    {
        public TKey Key = default;
        public TValue Value = default;
    }

    [Serializable]
    public class MultiValueDictionary<TKey, TValue> : Dictionary<TKey, List<TValue>>
    {
        public TKey Key = default;
        public TValue Value = default;

        public void Add(TKey key, TValue value)
        {
            List<TValue> values;
            if (!TryGetValue(key, out values))
            {
                values = new List<TValue>();
                this.Add(key, values);
            }

            values.Add(value);
        }
    }

    [Serializable]
    public class DictionarySerialize< TKey, TValue1, TValue2>
    {
        public TKey Key = default;
        public TValue1 Value1 = default;
        public TValue2 Value2 = default;
    }
}
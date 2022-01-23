using System;

namespace Models.ClassModels
{
    [Serializable]
    public class Named<TKey, TValue>
    {
        public TKey key = default;
        public TValue value = default;
    }
}
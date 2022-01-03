using System;
using System.Collections.Generic;
using UnityEngine;

namespace Utility
{
    [Serializable]
    public struct EventValue<T>
    {
        [SerializeField] private T _value;
        private Action<T> _action;

        public event Action<T> OnValueChanged
        {
            add
            {
                _action += value;
                value?.Invoke(_value);
            }
            remove => _action -= value;
        }

        public T Value
        {
            get => _value;
            set
            {
                if (!EqualityComparer<T>.Default.Equals(_value, value))
                {
                    _action?.Invoke(value);
                }

                _value = value;
            }
        }

        public EventValue(T value, Action<T> action)
        {
            _value = value;
            _action = action;
            _action?.Invoke(_value);
        }

        public EventValue(T value, Action<T> action, bool invokeOnInitialize)
        {
            _value = value;
            _action = action;
            if (invokeOnInitialize) _action?.Invoke(_value);
        }

        public EventValue(T value)
        {
            _value = value;
            _action = null;
        }

        public EventValue(Action<T> action, bool invokeOnInitialize = false)
        {
            _value = default;
            _action = action;
            if (invokeOnInitialize) _action?.Invoke(_value);
        }
    }
}
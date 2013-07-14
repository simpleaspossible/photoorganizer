using System;
using System.Collections.Generic;

namespace PhotoOrganizer.Commands.Plumbing
{
    public class ParameterResolver
    {
        private readonly Dictionary<Type, object> _types = new Dictionary<Type, object>();

        private readonly Dictionary<string ,Dictionary<Type,object>> _dictionaries = new Dictionary<string, Dictionary<Type, object>>();

        public T Resolve<T>()
        {
            if(_types.ContainsKey(typeof(T)))
            {
                return (T)_types[typeof(T)];
            }

            throw new NullReferenceException("Parameter Not Found");
        }

        public T Resolve<T>(string key)
        {
            if (_dictionaries.ContainsKey(key))
            {
                Dictionary<Type, object> dictionary = _dictionaries[key];

                return (T) dictionary[typeof(T)];
            }

            throw new NullReferenceException("Parameter Not Found");
        }

        public void Register<T>(object obj)
        {
            if(_types.ContainsKey(typeof(T)))
            {
                _types.Remove(typeof (T));
            }

            _types.Add(typeof(T), obj);
        }

        public void Register<T>(object obj, string key)
        {
            if (string.IsNullOrEmpty(key))
            {
                throw new NotSupportedException("A string key must be supplied to use this method");
            }

            if(_dictionaries.ContainsKey(key))
            {
                _dictionaries.Remove(key);
            }

            _dictionaries.Add(key, new Dictionary<Type, object> { { typeof(T), obj } });
        }
    }
}

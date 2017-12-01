using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Snappet.Logic
{
    /// <summary>
    /// IoC, Service Locator patter
    /// Resolver class to map concrete implementation
    /// </summary>
    public static class SimpleResolver
    {
        static Dictionary<Type, Type> _typeMapping;
        static Dictionary<Type, object> _singeletonMapping;

        static SimpleResolver()
        {
            _typeMapping = new Dictionary<Type, Type>();
            _singeletonMapping = new Dictionary<Type, object>();
        }

        public static T GetInstance<T>()
        {
            Type source = typeof(T);
            return (T)GetInstance(source);
        }

        public static object GetInstance(Type source)
        {
            if (_typeMapping.ContainsKey(source))
            {
                return Activator.CreateInstance(_typeMapping[source]);
            }
            else if (_singeletonMapping.ContainsKey(source))
            {
                return _singeletonMapping[source];
            }
            else throw new ArgumentException("This type is not mapped");
        }

        public static void MapType(Type sourceType, Type targetType)
        {
            _typeMapping.Add(sourceType, targetType);
        }

        public static void MapType(Type sourceType, object obj)
        {
            _singeletonMapping.Add(sourceType, obj);
        }

        public static void Clear()
        {
            _typeMapping.Clear();
            _singeletonMapping.Clear();
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Snappet.Logic
{
    /// <summary>
    /// IoC, Service Locator pattern
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

        /// <summary>
        /// This will reutn either a new object of the target type or an already existing object instance
        /// Throws an argument exception if the passed in type is not already mapped
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public static T GetInstance<T>()
        {
            Type source = typeof(T);
            return (T)GetInstance(source);
        }

        /// <summary>
        /// This will reutn either a new object of the target type or an already existing object instance
        /// Throws an argument exception if the passed in type is not already mapped
        /// </summary>
        /// <param name="source"></param>
        /// <returns></returns>
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

        /// <summary>
        /// Maps the source type into an instance of the target type
        /// The locator class will create a new instance everytime
        /// </summary>
        /// <param name="sourceType"></param>
        /// <param name="targetType"></param>
        public static void MapType(Type sourceType, Type targetType)
        {
            _typeMapping.Add(sourceType, targetType);
        }

        /// <summary>
        /// Maps the source type into the passed in object instance
        /// </summary>
        /// <param name="sourceType"></param>
        /// <param name="obj"></param>
        public static void MapType(Type sourceType, object obj)
        {
            _singeletonMapping.Add(sourceType, obj);
        }

        /// <summary>
        /// Clears all mappings
        /// </summary>
        public static void Clear()
        {
            _typeMapping.Clear();
            _singeletonMapping.Clear();
        }
    }
}

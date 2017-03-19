using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace Snappet.TestData.Builders
{
    internal interface IEntityBuilderFactory
    {
        EntityBuilder<TDataRecord, TEntity> GetEntityBuilder<TDataRecord, TEntity>() where TEntity : new();
    }

    internal class EntityBuilderFactory : IEntityBuilderFactory
    {
        private readonly Dictionary<string, Type> _entityBuilderMap;
        internal EntityBuilderFactory()
        {
            _entityBuilderMap = new Dictionary<string, Type>();

            var entityBuilderTypes = GetTypesMarkedAsEntityBuilder();
            CreateMappingForEachEntityBuilderType(entityBuilderTypes);
        }

        public EntityBuilder<TDataRecord, TEntity> GetEntityBuilder<TDataRecord, TEntity>() where TEntity : new() 
        {
            string key = string.Join(string.Empty, typeof(TDataRecord), typeof(TEntity));

            if (_entityBuilderMap.ContainsKey(key))
            {
                return Activator.CreateInstance(_entityBuilderMap[key]) as EntityBuilder<TDataRecord, TEntity>;
            }
            else
            {
                return null;
            }
        }

        private IEnumerable<Type> GetTypesMarkedAsEntityBuilder()
        {
            return Assembly.GetExecutingAssembly().GetTypes().Where(t => t.GetInterfaces().Contains(typeof(IEntityBuilder)));
        }

        private void CreateMappingForEachEntityBuilderType(IEnumerable<Type> entityBuilderTypes)
        {
            foreach (Type entityBuilderType in entityBuilderTypes)
            {
                Type baseType = entityBuilderType.BaseType;
                if (baseType == null || baseType.GenericTypeArguments.Length != 2)
                {
                    continue;
                }

                string entityType = string.Join<Type>(string.Empty, baseType.GenericTypeArguments);
                if (!_entityBuilderMap.ContainsKey(entityType))
                {
                    _entityBuilderMap.Add(entityType, entityBuilderType);
                }
            }
        }
    }
}
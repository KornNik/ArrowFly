using System;
using System.Collections.Generic;

namespace Helpers
{
    class ServiceLocator<T> : IServiceLocator<T>
    {
        private Dictionary<Type, T> _itemsMap;

        public ServiceLocator()
        {
            _itemsMap = new Dictionary<Type, T>();
        }

        public V GetService<V>() where V : T
        {
            var type = typeof(V);

            if (!_itemsMap.ContainsKey(type))
            {
                throw new Exception($"Items type is dosnt exist{type}");
            }
            var requestedService = (V)_itemsMap[type];

            return requestedService;
        }

        public V Register<V>(V newService) where V : T
        {
            var type = newService.GetType();

            if (_itemsMap.ContainsKey(type))
            {
                throw new Exception($"Items type is already exist{type}");
            }

            _itemsMap[type] = newService;

            return newService;
        }

        public void Unregister<V>(V service) where V : T
        {
            var type = service.GetType();

            if (_itemsMap.ContainsKey(type))
            {
                _itemsMap.Remove(type);
            }
        }
    }
}

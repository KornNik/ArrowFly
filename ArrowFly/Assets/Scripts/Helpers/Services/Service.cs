using System;

namespace Helpers
{
    class Service<T>
    {
        public event Action<T> ObjectIsLoaded;

        private T _servicesObject;
        public T ServicesObject => _servicesObject;

        public virtual void SetObject(T servicesObject)
        {
            _servicesObject = servicesObject;
            ObjectIsLoaded?.Invoke(_servicesObject);
        }
    }
}

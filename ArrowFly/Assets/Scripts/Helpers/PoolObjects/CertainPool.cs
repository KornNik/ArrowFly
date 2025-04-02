using System;
using UnityEngine;
using System.Linq;
using System.Collections.Generic;
using Object = UnityEngine.Object;

namespace Helpers
{
    sealed class CertainPool<TPoolableObject> : PoolObjects<TPoolableObject> where TPoolableObject :
        MonoBehaviour, IPoolable
    {
        public Action<TPoolableObject> ObjectInstantiated;
        
        private TPoolableObject _poolObject;
        private List<TPoolableObject> _poolablesList;

        public CertainPool(int capacityPool, Transform poolTransform, TPoolableObject poolObject) :
            base(capacityPool, poolTransform)
        {
            _objectPool = new Dictionary<TPoolableObject, HashSet<IPoolable>>();
            _poolObject = poolObject;
        }

        public override IPoolable GetObject(TPoolableObject poolable)
        {
            IPoolable result;
            result = GetAllObjects(GetListObject(poolable));
            return result;
        }
        public void ReturnAllToPool()
        {
            var result = GetListObject(_poolObject);
            foreach (var item in result)
            {
                item.ReturnToPool();
            }
        }

        protected override void RemovePool()
        {
            ReturnAllToPool();
            _poolablesList.Clear();
            base.RemovePool();
        }

        private IPoolable GetAllObjects(HashSet<IPoolable> poolablesHash)
        {
            var certainPoolable = poolablesHash.FirstOrDefault(a => !a.PoolableObject.activeSelf);
            if (certainPoolable == null)
            {
                var poolable = _poolObject;
                InstantiatePoolables(_poolObject, poolablesHash);
                GetAllObjects(poolablesHash);
            }
            certainPoolable = poolablesHash.FirstOrDefault(a => !a.PoolableObject.activeSelf);
            return certainPoolable;
        }
        private void InstantiatePoolables(TPoolableObject poolable, HashSet<IPoolable> poolablesHash)
        {
            for (var i = 0; i < _capacityPool; i++)
            {
                var instantiate = Object.Instantiate(poolable);
                ReturnToPool(instantiate.transform);
                instantiate.PoolTransform = _poolTransform;
                poolablesHash.Add(instantiate);
                _poolablesList.Add(instantiate);
                ObjectInstantiated?.Invoke(instantiate);
            }
        }
    }
}

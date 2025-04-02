using UnityEngine;

namespace Helpers
{
    interface IPoolable
    {
        Transform PoolTransform { get; set; }
        GameObject PoolableObject { get; set; }
        
        void ReturnToPool();
        void ActiveObject();
    }
}

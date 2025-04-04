using UnityEngine;
using Helpers;

namespace Behaviours
{
    abstract class  Projectile : MonoBehaviour, IPoolable
    {
        [SerializeField] protected Rigidbody2D _rigidbody;

        private Transform _parentTransform;
        public Transform PoolTransform { get => _parentTransform; set => _parentTransform = value; }
        public GameObject PoolableObject { get => gameObject; set => PoolableObject.SetActive(value); }

        protected virtual void Awake()
        {
            _parentTransform = transform.GetComponentInParent<Transform>();
        }

        public void ReturnToPool()
        {
            _rigidbody.simulated = false;
            _rigidbody.velocity = Vector2.zero;
            transform.SetParent(PoolTransform);
            transform.localPosition = Vector3.zero;
            transform.localRotation = Quaternion.identity;
            PoolableObject.SetActive(false);
            CancelInvoke(nameof(ReturnToPool));

            if (!PoolTransform)
            {
                Destroy(gameObject);
            }
        }
        public void ActiveObject()
        {
            transform.SetParent(null);
            CancelInvoke(nameof(ReturnToPool));
            PoolableObject.SetActive(true);
        }
    }
}

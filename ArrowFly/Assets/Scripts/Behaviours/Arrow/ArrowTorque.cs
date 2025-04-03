using Helpers;
using System;
using UnityEngine;

namespace Behaviours
{
    sealed class ArrowTorque : MonoBehaviour, IPoolable
    {
        public event Action IsCollision;

        [SerializeField] private Rigidbody2D _rigidbody;
        [SerializeField] private ArrowAnimation _arrowAnimation;

        private Vector2 _velocity;
        private float _angle;
        private Transform _parentTransform;

        public Transform PoolTransform { get => _parentTransform; set => _parentTransform = value; }
        public GameObject PoolableObject { get => gameObject; set => PoolableObject.SetActive(value); }

        private void Awake()
        {
            _parentTransform = transform.GetComponentInParent<Transform>();
        }
        private void FixedUpdate()
        {
            _velocity = _rigidbody.velocity;
            _angle = Mathf.Atan2(_velocity.y, _velocity.x) * Mathf.Rad2Deg;
            transform.rotation = Quaternion.AngleAxis(_angle, Vector3.forward);
        }

        public void Throw(Vector2 velocity)
        {
            Invoke(nameof(ReturnToPool), 2f);
            _rigidbody.simulated = true;
            _rigidbody.velocity = velocity;
        }
        public void DestructProjectile()
        {
            _rigidbody.simulated = false;
            _rigidbody.velocity = Vector2.zero;
            CancelInvoke(nameof(ReturnToPool));
            Invoke(nameof(ReturnToPool), 0.5f);
        }
        private void OnCollisionEnter2D(Collision2D collision)
        {
            CancelInvoke(nameof(ReturnToPool));
            DestructProjectile();
            IsCollision?.Invoke();
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
            CancelInvoke(nameof(ReturnToPool));
            PoolableObject.SetActive(true);
        }
    }
}

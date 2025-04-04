using System;
using UnityEngine;
using Data;
using Helpers.Managers;

namespace Behaviours
{
    sealed class Arrow : Projectile
    {
        public event Action IsCollision;

        [SerializeField] private ArrowAnimation _arrowAnimation;
        [SerializeField] private ArrowData _data;

        private ProjectileTorque _projectileTorque;

        protected override void Awake()
        {
            base.Awake();
            _projectileTorque = new ProjectileTorque(transform);
        }
        private void FixedUpdate()
        {
            _projectileTorque.SetAngle(_rigidbody.velocity);
        }

        public void Throw(Vector2 velocity)
        {
            ActiveObject();
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
            if (collision.gameObject.layer == LayerMask.NameToLayer(LayersManager.TARGET))
            {
                MakeSoundEvent.Trigger(new SoundEventInfo(_data.HitClip, transform.position));
            }
            IsCollision?.Invoke();
            CancelInvoke(nameof(ReturnToPool));
            DestructProjectile();
        }
    }
}

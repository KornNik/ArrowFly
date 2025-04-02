using UnityEngine;

namespace Behaviours
{
    sealed class ArrowTorque : MonoBehaviour
    {
        [SerializeField] private Rigidbody2D _rigidbody;

        private Vector2 _velocity;
        private float _angle;

        private void FixedUpdate()
        {
            _velocity = _rigidbody.velocity;
            _angle = Mathf.Atan2(_velocity.y, _velocity.x) * Mathf.Rad2Deg;
            transform.rotation = Quaternion.AngleAxis(_angle, Vector3.forward);
        }

        public void Throw(Vector2 velocity)
        {
            _rigidbody.simulated = true;
            _rigidbody.velocity = _velocity;
        }
    }
}

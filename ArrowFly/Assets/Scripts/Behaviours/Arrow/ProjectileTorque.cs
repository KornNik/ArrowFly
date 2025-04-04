using UnityEngine;

namespace Behaviours
{
    sealed class ProjectileTorque
    {
        private Vector2 _velocity;
        private float _angle;
        private Transform _projectileTransform;

        public ProjectileTorque(Transform projectileTransform)
        {
            _projectileTransform = projectileTransform;
        }

        public void SetAngle(Vector2 velocity)
        {
            _velocity = velocity;
            _angle = Mathf.Atan2(_velocity.y, _velocity.x) * Mathf.Rad2Deg;
            _projectileTransform.rotation = Quaternion.AngleAxis(_angle, Vector3.forward);
        }
    }
}

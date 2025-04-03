using Data;
using Helpers;
using System;
using UnityEngine;

namespace Behaviours
{
    [Serializable]
    struct IKTransforms
    {
        public Transform LeftHand;
        public Transform RightHand;
        public Transform ChestTarget;
    }
    sealed class Launcher : MonoBehaviour, IBow
    {
        [SerializeField] private Transform _spawnPoint;
        [SerializeField] private ArrowTorque _arrowPrefab;
        [SerializeField] private LineRenderer _lineRenderer;
        [SerializeField] private BowData _data;
        [SerializeField] private IKTransforms _ikTargets;

        private LineDrawer _lineDrawer;
        private Vector2 _velocity;
        private CertainPool<ArrowTorque> _arrowPool;
        private ArrowTorque _currentHoldArrow;

        public IKTransforms IkTargets => _ikTargets;

        private void Awake()
        {
            _lineDrawer = new LineDrawer(_lineRenderer, _spawnPoint);
            _arrowPool = new CertainPool<ArrowTorque>(3, _spawnPoint, _arrowPrefab);
        }

        public void OnStartDrawBow()
        {
            _currentHoldArrow = _arrowPool.GetObject() as ArrowTorque;
            _currentHoldArrow.ActiveObject();
        }
        public void OnHoldDraw(Vector2 startMousePosition, Vector2 endMousePosition)
        {
            var dragValue = (startMousePosition - endMousePosition);
            _velocity = dragValue * _data.LaunchForce;
            _lineDrawer.DrawTrajectory(_velocity);
            Rotate();
        }
        public void OnReleaseDraw()
        {
            _lineDrawer.ClearLine();
        }
        public void ThrowArrow()
        {
            if (_currentHoldArrow == null) { return; }
            _currentHoldArrow.Throw(_velocity);
        }
        public void Rotate()
        {
            float angle = Mathf.Atan2(_velocity.y, _velocity.x) * Mathf.Rad2Deg;
            transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
        }
    }
}

using Data;
using Helpers;
using System;
using UnityEngine;

namespace Behaviours
{
    [Serializable]
    struct IKTransforms
    {
        public Transform AimTarget;
    }
    sealed class Launcher : MonoBehaviour, IBow
    {
        [SerializeField] private Transform _spawnPoint;
        [SerializeField] private Arrow _arrowPrefab;
        [SerializeField] private LineRenderer _lineRenderer;
        [SerializeField] private BowData _data;
        [SerializeField] private IKTransforms _ikTargets;

        private LineDrawer _lineDrawer;
        private Vector2 _velocity;
        private CertainPool<Arrow> _arrowPool;
        private Arrow _currentHoldArrow;
        private ProjectileTorque _projectileTorque;

        public IKTransforms IkTargets => _ikTargets;

        private void Awake()
        {
            _projectileTorque = new ProjectileTorque(transform);
            _lineDrawer = new LineDrawer(_lineRenderer, _spawnPoint);
            _arrowPool = new CertainPool<Arrow>(3, _spawnPoint, _arrowPrefab);
        }

        public void OnStartDrawBow()
        {
            _currentHoldArrow = _arrowPool.GetObject() as Arrow;
            MakeSoundEvent.Trigger(new SoundEventInfo(_data.StartDrawAudioClip, transform.position));
        }
        public void OnHoldDraw(Vector2 startMousePosition, Vector2 endMousePosition)
        {
            var dragValue = (startMousePosition - endMousePosition);
            _velocity = dragValue * _data.LaunchForce;
            _lineDrawer.DrawTrajectory(_velocity);
            _projectileTorque.SetAngle(_velocity);
        }
        public void OnReleaseDraw()
        {
            _lineDrawer.ClearLine();
            MakeSoundEvent.Trigger(new SoundEventInfo(_data.ReleaseDrawAudioClip, transform.position));
        }
        public void ThrowArrow()
        {
            if (_currentHoldArrow == null) { return; }
            _currentHoldArrow.Throw(_velocity);
        }
    }
}

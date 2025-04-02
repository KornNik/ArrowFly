using Helpers;
using Helpers.Extensions;
using UnityEngine;
using UnityEngine.InputSystem;

namespace Behaviours
{
    sealed class Launcher : MonoBehaviour
    {
        [SerializeField] private Transform _spawnPoint;
        [SerializeField] private ArrowTorque _arrow;
        [SerializeField] private LineRenderer _lineRenderer;
        [SerializeField] private float _launchForce = 1.5f;

        private LineDrawer _lineDrawer;
        private Vector2 _velocity;
        private Vector2 _startMousePosition;
        private Vector2 _endMousePosition;
        private InputActions _inputs;

        private void Awake()
        {
            _lineDrawer = new LineDrawer(_lineRenderer, _spawnPoint);
            _inputs = Services.Instance.Inputs.ServicesObject;
        }

        private void Update()
        {
            if (_inputs == null) { return; }

            var isInProgress = _inputs.PlayerActionList[InputActionManager.FIRE].IsInProgress();
            var isPressed = _inputs.PlayerActionList[InputActionManager.FIRE].IsPressed();
            var isPerformedThisFrame = _inputs.PlayerActionList[InputActionManager.FIRE].WasPerformedThisFrame();
            var isPressedThisFrame = _inputs.PlayerActionList[InputActionManager.FIRE].WasPressedThisFrame();
            var isReleasedThisFrame = _inputs.PlayerActionList[InputActionManager.FIRE].WasReleasedThisFrame();

            Debug.Log($"isInProgress = {isInProgress} isPressed = {isPressed} " +
                $"isPerformedThisFrame = {isPerformedThisFrame} isPressedThisFrame = {isPressedThisFrame} " +
                $"isReleasedThisFrame = {isReleasedThisFrame}");
            if (isPerformedThisFrame)
            {
                _startMousePosition = Mouse.current.position.ReadValue();
            }
            if (isReleasedThisFrame)
            {
                _lineDrawer.ClearLine();
                _arrow.Throw(_velocity);
            }
            if (isInProgress)
            {
                _endMousePosition = Mouse.current.position.ReadValue();
                var dragValue = (_startMousePosition - _endMousePosition);
                _velocity = dragValue * _launchForce * 0.02f;
                RotateBow(_endMousePosition);
                _lineDrawer.DrawTrajectory(_velocity);
            }
        }

        private void RotateBow(Vector2 MousePosition)
        {
            float angle = Mathf.Atan2(_velocity.y, _velocity.x) * Mathf.Rad2Deg;
            transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
        }
    }
}

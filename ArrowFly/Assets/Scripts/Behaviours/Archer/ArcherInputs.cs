using Helpers;
using Helpers.Extensions;
using System;
using UnityEngine;
using UnityEngine.InputSystem;

namespace Behaviours
{
    sealed class ArcherInputs
    {
        public event Action ReleasDraw;
        public event Action PerformDraw;
        public event Action InProgressDraw;
        public event Action<Vector2,Vector2> DrawDragValue;

        private InputActions _inputs;
        private Vector2 _startMousePosition;
        private Vector2 _endMousePosition;

        public ArcherInputs()
        {
            _inputs = Services.Instance.Inputs.ServicesObject;
        }
        public void UpdateInputs()
        {
            if (_inputs == null) { return; }

            var isInProgress = _inputs.PlayerActionList[InputActionManager.DRAW].IsInProgress();
            var isPressed = _inputs.PlayerActionList[InputActionManager.DRAW].IsPressed();
            var isPerformedThisFrame = _inputs.PlayerActionList[InputActionManager.DRAW].WasPerformedThisFrame();
            var isPressedThisFrame = _inputs.PlayerActionList[InputActionManager.DRAW].WasPressedThisFrame();
            var isReleasedThisFrame = _inputs.PlayerActionList[InputActionManager.DRAW].WasReleasedThisFrame();

            if (isPerformedThisFrame)
            {
                PerformDraw?.Invoke();
                _startMousePosition = Mouse.current.position.ReadValue();
            }
            if (isReleasedThisFrame)
            {
                ReleasDraw?.Invoke();
            }
            if (isInProgress)
            {
                _endMousePosition = Mouse.current.position.ReadValue();
                InProgressDraw?.Invoke();
                DrawDragValue?.Invoke(_startMousePosition, _endMousePosition);
            }
        }
    }
}

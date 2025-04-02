using System;
using UnityEngine;

namespace Behaviours
{
    abstract class BaseStateController
    {
        protected IState _previousState;
        protected IState _currentState;

        public BaseStateController()
        {
            InitializeStates();
        }

        protected abstract void InitializeStates();

        protected virtual void StartState(IState startingState)
        {
            ChangeState(startingState);
        }

        public void ChangeState(IState newState)
        {
            if (ReferenceEquals(newState, null))
            {
                throw new Exception($"{this} try to set new state that is equal null");
            }
            if (!ReferenceEquals(_currentState, null))
            {
                _currentState.ExitState();
            }
            else
            {
                _previousState = newState;
            }
            _previousState = _currentState;
            _currentState = newState;
            _currentState.EnterState();
            Debug.Log($"Current State is {_currentState}");
        }

        public void Update()
        {
            _currentState.LogicUpdate();
        }

        public void FixedUpdate()
        {
            _currentState.LogicFixedUpdate();
        }
        public void LateUpdate()
        {
            _currentState.LogicLateUpdate();
        }

        public IState GetPreviousState()
        {
            if (!ReferenceEquals(_previousState, null))
            {
                return _previousState;
            }
            return null;
        }
    }
}
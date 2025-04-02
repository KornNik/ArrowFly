using System;
using System.Collections;
using UnityEngine;

namespace Controllers
{
    sealed class TaskCustom : ITask
    {
        private TaskPriorityEnum _taskPriority = TaskPriorityEnum.Default;

        private Action _feedback;
        private MonoBehaviour _coroutineHost;
        private Coroutine _coroutine;
        private IEnumerator _taskAction;

        public TaskCustom(IEnumerator taskAction, TaskPriorityEnum priority = TaskPriorityEnum.Default)
        {
            ///Получить монобех для корутины
            _taskPriority = priority;
            _taskAction = taskAction;
        }

        public TaskPriorityEnum Priority => _taskPriority;

        public static TaskCustom Create(IEnumerator taskAction, TaskPriorityEnum priority = TaskPriorityEnum.Default)
        {
            return new TaskCustom(taskAction, priority);
        }

        public void Start()
        {
            if (_coroutine == null)
            {
                _coroutine = _coroutineHost.StartCoroutine(RunTask());
            }
        }

        public void Stop()
        {
            if (_coroutine != null)
            {
                _coroutineHost.StopCoroutine(_coroutine);
                _coroutine = null;
            }
        }

        public ITask Subscribe(Action completeCallback)
        {
            _feedback += completeCallback;

            return this;
        }

        private IEnumerator RunTask()
        {
            yield return _taskAction;

            CallSubscribe();
        }
        private void CallSubscribe()
        {
            if (_feedback != null)
            {
                _feedback();
            }
        }
    }
}

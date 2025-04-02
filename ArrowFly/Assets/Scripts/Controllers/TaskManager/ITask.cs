using System;

namespace Controllers
{
    public enum TaskPriorityEnum
    {
        Default,
        High,
        Interrupt
    }
    interface ITask
    {
        TaskPriorityEnum Priority { get; }
        void Start();
        ITask Subscribe(Action completeCallback);
        void Stop();
    }
}

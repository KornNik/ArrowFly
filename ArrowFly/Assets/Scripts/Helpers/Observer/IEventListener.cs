namespace Helpers
{
    interface IEventListener<T> : IEventListenerBase
    {
        void OnEventTrigger(T eventType);
    }
}

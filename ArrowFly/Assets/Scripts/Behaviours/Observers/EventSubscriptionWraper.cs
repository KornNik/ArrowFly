using System.Collections.Generic;

namespace Behaviours
{
    sealed class EventSubscriptionWraper : IEventSubscription
    {
        private List<IEventSubscription> _events;

        public EventSubscriptionWraper(int listSize = 1)
        {
            _events = new List<IEventSubscription>();
        }

        public void Subscribe()
        {
            if(!IsHasEvents()) { return; }
            foreach (var subscription in _events)
            {
                subscription.Subscribe();
            }
        }
        public void Unsubscribe()
        {
            if (!IsHasEvents()) { return; }
            foreach (var subscription in _events)
            {
                subscription.Unsubscribe();
            }
        }

        public EventSubscriptionWraper AddEvent(IEventSubscription eventSubscription)
        {
            _events.Add(eventSubscription);
            return this;
        }
        public EventSubscriptionWraper RemoveEvent(IEventSubscription eventSubscription)
        {
            _events.Remove(eventSubscription);
            return this;
        }

        private bool IsHasEvents()
        {
            if (_events == null) { return false; }
            if (_events.Count == 0) { return false; }
            return true;
        }
    }
}

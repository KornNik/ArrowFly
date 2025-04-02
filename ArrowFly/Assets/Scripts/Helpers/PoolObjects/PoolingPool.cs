using UnityEngine;
using System.Collections.Generic;

namespace Helpers
{
    public abstract class PollingPool<T> where T : Component
    {
        private readonly T _prefab;

        private readonly Queue<T> _pool = new Queue<T>();
        private readonly LinkedList<T> _inuse = new LinkedList<T>();
        private readonly Queue<LinkedListNode<T>> _nodePool = new Queue<LinkedListNode<T>>();

        private int _lastCheckFrame = -1;

        protected PollingPool(T prefab)
        {
            this._prefab = prefab;
        }

        private void CheckInUse()
        {
            var node = _inuse.First;
            while (node != null)
            {
                var current = node;
                node = node.Next;

                if (!IsActive(current.Value))
                {
                    current.Value.gameObject.SetActive(false);
                    _pool.Enqueue(current.Value);
                    _inuse.Remove(current);
                    _nodePool.Enqueue(current);
                }
            }
        }

        protected T Get()
        {
            T item;

            if (_lastCheckFrame != Time.frameCount)
            {
                _lastCheckFrame = Time.frameCount;
                CheckInUse();
            }

            if (_pool.Count == 0)
                item = GameObject.Instantiate(_prefab);
            else
                item = _pool.Dequeue();

            if (_nodePool.Count == 0)
                _inuse.AddLast(item);
            else
            {
                var node = _nodePool.Dequeue();
                node.Value = item;
                _inuse.AddLast(node);
            }

            item.gameObject.SetActive(true);

            return item;
        }

        protected abstract bool IsActive(T component);
    }
}
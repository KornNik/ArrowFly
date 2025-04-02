using System;
using System.Collections.Generic;
using UnityEngine;

namespace Helpers
{
	class BasePool<T>
	{
		private readonly Func<T> _preLoadFunc;
		private readonly Action<T> _getAction;
		private readonly Action<T> _returnAction;

		private Queue<T> _pool = new Queue<T>();
		private List<T> _activeObjects = new List<T>();

		public BasePool(Func<T> preLoad, Action<T> getAction, Action<T> returnAction, int objectsCount)
		{
			_preLoadFunc = preLoad;
			_getAction = getAction;
			_returnAction = returnAction;

			if (ReferenceEquals(_preLoadFunc, null))
			{
				Debug.LogError("preLoadFunc is null");
				return;
			}

			for (int i = 0; i < objectsCount; i++)
			{
				Return(preLoad());
			}
		}

		public T Get()
		{
			T item = _pool.Count > 0 ? _pool.Dequeue() : _preLoadFunc();
			_getAction(item);
			_activeObjects.Add(item);
			return item;
		}
		public void Return(T item)
		{
			_returnAction(item);
			_pool.Enqueue(item);
			_activeObjects.Remove(item);
		}
		public void ReturnAll()
		{
			for (int i = 0; i < _activeObjects.Count; i++)
			{
				Return(_activeObjects[i]);
			}
		}
	}
}
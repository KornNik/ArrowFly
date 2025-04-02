using UnityEngine;

namespace Helpers
{
	class GameObjectPool : BasePool<GameObject>
	{
		public GameObjectPool(GameObject prefab, int objectsCount) : base(() => PreLoad(prefab), GetAction, ReturnAction, objectsCount)
		{

		}

		public static GameObject PreLoad(GameObject prefab) => Object.Instantiate(prefab);
		public static void GetAction(GameObject gameObject) => gameObject.SetActive(true);
		public static void ReturnAction(GameObject gameObject) => gameObject.SetActive(false);
	}
}
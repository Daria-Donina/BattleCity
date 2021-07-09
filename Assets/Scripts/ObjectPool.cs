using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts
{
	/// <summary>
	/// Class implementing pool of objects.
	/// </summary>
	/// <typeparam name="T"> Type of object to store in pool.</typeparam>
	public class ObjectPool<T> : MonoBehaviour where T : MonoBehaviour
	{
		[SerializeField]
		private T prefab;

		private readonly Queue<T> _objectsQueue = new Queue<T>();
		private int _objectsAmount = 10;

		private void Awake()
		{
			for (int i = 0; i < _objectsAmount; i++)
			{
				_objectsQueue.Enqueue(CreateObject());
			}
		}

		/// <summary>
		/// Get and instantiate object from the pool.
		/// </summary>
		/// <param name="position"> Position to instantiate object.</param>
		/// <returns> Instantiated object.</returns>
		public T GetObject(Vector3 position)
		{
			T obj;

			if (_objectsQueue.Count == 0)
			{
				_objectsAmount++;
				obj = CreateObject();
			}
			else
			{
				obj = _objectsQueue.Dequeue();
			}

			obj.gameObject.SetActive(true);
			obj.transform.position = position;
			return obj;
		}

		public void ReturnObject(T obj)
		{
			obj.gameObject.SetActive(false);
			obj.transform.SetParent(transform);
			obj.transform.position = transform.position;
			obj.transform.rotation = transform.rotation;

			_objectsQueue.Enqueue(obj);
		}

		private T CreateObject()
		{
			var obj = Instantiate(prefab, transform);

			obj.transform.SetParent(transform);
			obj.gameObject.SetActive(false);

			return obj;
		}
	}
}

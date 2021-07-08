using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Scripts
{
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

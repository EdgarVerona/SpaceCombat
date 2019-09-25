using Assets.Scripts.Components.Pools;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.ObjectPools
{
	/// <summary>
	/// First pass at a pool for reusing game objects.  Might be enough for my needs, we'll see.
	/// </summary>
	public class GameObjectPool
	{
		private Queue<PooledObject> _objects;

		private PooledObject _prefab;

		public GameObjectPool(PooledObject prefab)
		{
			_prefab = prefab;
			_objects = new Queue<PooledObject>(_prefab.PoolCount);
			
			this.AddObjects();
		}

		private void AddObjects()
		{
			Debug.Log($"Adding {_prefab.PoolCount} items to the '{_prefab.PoolIdentifier}' GameObjectPool, prefab name '{_prefab.name}'");

			for (int i = 0; i < _prefab.PoolCount; i++)
			{
				var newObject = UnityEngine.Object.Instantiate(_prefab, new Vector3(0, 0, 0), Quaternion.identity);
				newObject.gameObject.SetActive(false);
				_objects.Enqueue(newObject);
			}
		}

		public T GetInstance<T>() where T : PooledObject
		{
			if (_objects.Count == 0)
			{
				if (_prefab.IsPoolExpandable)
				{
					AddObjects();
				}
				else
				{
					return null;
				}
			}

			var newObject = _objects.Dequeue() as T;
			newObject.Initialize();

			return newObject;
		}

		public void RecycleInstance(PooledObject gameObject)
		{
			gameObject.gameObject.SetActive(false);
			gameObject.transform.position = new Vector3(0, 0, 0);
			gameObject.transform.rotation = Quaternion.identity;
			_objects.Enqueue(gameObject);
		}
	}
}

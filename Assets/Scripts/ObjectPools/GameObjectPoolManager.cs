using Assets.Scripts.Components.Pools;
using Assets.Scripts.Lib.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.ObjectPools
{
	/// <summary>
	/// A singleton that controls the allocation of Game Objects from pools, allowing the pools to be shared between components.
	/// </summary>
	public class GameObjectPoolManager
	{
		private Dictionary<string, GameObjectPool> _pools;

		private static GameObjectPoolManager _instance;

		public static GameObjectPoolManager Instance
		{
			get
			{
				if (_instance == null)
				{
					_instance = new GameObjectPoolManager();
				}

				return _instance;
			}
		}

		private GameObjectPoolManager()
		{
			_pools = new Dictionary<string, GameObjectPool>();
		}

		public T GetInstance<T>(T prefab) where T : PooledObject
		{
			var existingPool = _pools.TryGetValueOrDefault(prefab.PoolIdentifier);

			if (existingPool == null)
			{
				existingPool = new GameObjectPool(prefab);

				_pools.Add(prefab.PoolIdentifier, existingPool);
			}

			return existingPool.GetInstance<T>();
		}

		public void RecycleInstance(PooledObject objectToRecycle)
		{
			var existingPool = _pools.TryGetValueOrDefault(objectToRecycle.PoolIdentifier);

			if (existingPool == null)
			{
				Debug.Log($"Could not recycle {objectToRecycle.PoolIdentifier}, no pool found.");
			}
			else
			{
				existingPool.RecycleInstance(objectToRecycle);
			}
		}
	}
}

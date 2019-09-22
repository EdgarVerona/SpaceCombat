using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Scripts.Components.Pools
{
	/// <summary>
	/// For a prefab object to be pooled, it must have this behavior.
	/// </summary>
	public class PooledObject : MonoBehaviour
	{
		public string PoolIdentifier;

		public int PoolCount = 50;

		public bool IsPoolExpandable = true;

		public virtual void Initialize()
		{
			this.gameObject.SetActive(true);
		}
	}
}

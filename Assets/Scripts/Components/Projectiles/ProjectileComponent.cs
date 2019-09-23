using Assets.ObjectPools;
using Assets.Scripts.Components.Pools;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Scripts.Components.Projectiles
{
	public class ProjectileComponent : PooledObject
	{
		public float Velocity;

		public float LifetimeInSeconds;

		public float DamagePoints;

		private float _timeCreated;

		public override void Initialize()
		{
			base.Initialize();

			_timeCreated = Time.time;
		}

		public void FixedUpdate()
		{
			// If its lifetime has elapsed, get rid of it.
			if ((_timeCreated + this.LifetimeInSeconds) <= Time.time)
			{
				GameObjectPoolManager.Instance.RecycleInstance(this);
			}
			else
			{
				// Move it forward in space.
				this.transform.position += this.transform.forward * this.Velocity * Time.fixedDeltaTime;
			}
		}
	}
}

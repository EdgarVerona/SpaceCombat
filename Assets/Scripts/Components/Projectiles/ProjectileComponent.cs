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
	/// <summary>
	/// $NOTE - This is more of a "straight-firing projectile" component.
	/// Consider if Damage should be separated from this and pulled into its own concept: perhaps projectiles might not cause
	/// damage?  Or I can share the Damage concept between multiple types of projectiles.
	/// 
	/// Also, should damage be associated with a weapon or the projectile?  Another good reason to split it, perhaps either
	/// might apply in some circumstances.
	/// 
	/// Also, ProjectileComponent could be a reasonable base class for other types of projectiles than a "fire straight forward" variety.
	/// </summary>
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

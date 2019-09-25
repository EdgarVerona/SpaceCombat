using Assets.ObjectPools;
using Assets.Scripts.Components.Pools;
using Assets.Scripts.Components.Projectiles;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Scripts.Components.Weapons
{
	/// <summary>
	/// Controls the association of a piece of geometry that is considered a projectile-firing weapon
	/// with the point at which the projectiles should be launched and the projectile being launched.
	/// 
	/// Has some basic properties about the weapon, and controls when it can fire.
	/// 
	/// ASSUMES that the weapon will fire out of the local "forward" direction (blue arrow) of the LaunchPoint,
	/// and that the projectile will also be fired facing its local "forward" direction.
	/// </summary>
	public class WeaponComponent : MonoBehaviour
	{
		public ProjectileComponent ProjectilePrefab;

		public GameObject LaunchPoint;

		public float ReloadTimeInSeconds;

		private float _timeSinceLastFired = 0.0f;

		public bool TryFire()
		{
			bool canFire = (_timeSinceLastFired + this.ReloadTimeInSeconds) <= Time.time;

			if (canFire)
			{
				var newProjectile = GameObjectPoolManager.Instance.GetInstance(this.ProjectilePrefab);

				if (newProjectile != null)
				{
					newProjectile.transform.position = this.LaunchPoint.transform.position;
					newProjectile.transform.rotation = this.LaunchPoint.transform.rotation;

					_timeSinceLastFired = Time.time;
				}
			}

			return canFire;
		}

		public Transform GetLaunchTransform()
		{
			return this.LaunchPoint.transform;
		}

		public Vector3 GetLaunchPosition()
		{
			return this.LaunchPoint.transform.position;
		}

		public Quaternion GetLaunchRotation()
		{
			return this.LaunchPoint.transform.rotation;
		}
	}
}

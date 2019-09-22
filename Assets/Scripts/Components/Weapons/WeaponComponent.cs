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
	}
}

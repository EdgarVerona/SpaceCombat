using Assets.Scripts.Components.Weapons;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Components.Ships
{
	public class BaseShipStats : MonoBehaviour
	{
		public float AccelerationRate;

		public float DecelerationRate;

		public float TurnRate;

		public float PitchRate;

		public float TwistRate;
		
		public float WeaponDelayRateInSeconds;

		private float _lastTimeWeaponFired = 0.0f;

		private int _weaponFireIndex = 0;

		private List<WeaponComponent> _weapons;

		private void Start()
		{
			this._weapons = new List<WeaponComponent>();

			foreach (Transform child in this.transform)
			{
				var weaponComponent = child.GetComponent<WeaponComponent>();

				if (weaponComponent != null)
				{
					this._weapons.Add(weaponComponent);
				}
			}
		}

		public void FireWeapon()
		{
			if (_weapons.Any())
			{
				if ((_lastTimeWeaponFired + this.WeaponDelayRateInSeconds) <= Time.time)
				{
					// If the current weapon fires, cycle to the next one.
					if (_weapons[_weaponFireIndex].TryFire())
					{
						_weaponFireIndex = (_weaponFireIndex + 1) % _weapons.Count;
						_lastTimeWeaponFired = Time.time;
					}
				}
			}
		}
	}
}

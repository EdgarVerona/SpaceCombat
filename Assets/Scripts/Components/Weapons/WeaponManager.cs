using Assets.Scripts.Components.Weapons;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Scripts.Components.Weapons
{
	public class WeaponManager
	{
		private int _weaponFireIndex = 0;

		private List<WeaponComponent> _weapons;

		public WeaponManager(GameObject parentObject)
		{
			this._weapons = new List<WeaponComponent>();

			foreach (Transform child in parentObject.transform)
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
				// If the current weapon fires, cycle to the next one.
				if (_weapons[_weaponFireIndex].TryFire())
				{
					_weaponFireIndex = (_weaponFireIndex + 1) % _weapons.Count;
				}
			}
		}
	}
}

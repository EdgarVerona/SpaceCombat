using Assets.Scripts.Components.Weapons;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Scripts.Components.Weapons
{
	/// <summary>
	/// $NOTE This weapon manager is the start of an idea I had to provide X-wing like weapon grouping and linking,
	/// but I'm already starting to have my doubts about it.  I'm going to roll with it for now, but should re-assess
	/// later if I want to use a different pattern as I start to actually implement grouping/linking.
	/// </summary>
	public class WeaponManager
	{
		private int _weaponFireIndex = 0;

		private List<WeaponComponent> _weapons;

		public WeaponManager(GameObject parentObject)
		{
			_weapons = new List<WeaponComponent>();

			var weaponComponents = parentObject.GetComponentsInChildren<WeaponComponent>();

			if (weaponComponents != null)
			{
				_weapons.AddRange(weaponComponents);
			}
		}

		public void FireIfTargetable(GameObject targetObject, float minimumAttackAngle, float minimumDistanceToAttack)
		{
			if (_weapons.Any())
			{
				for (int index = 0; index < _weapons.Count; index++)
				{
					var currentWeapon = _weapons[_weaponFireIndex];

					var vectorToTarget = targetObject.transform.position - currentWeapon.GetLaunchPosition();

					var distanceToPlayer = vectorToTarget.magnitude;

					if (distanceToPlayer <= minimumDistanceToAttack)
					{
						var angleToTarget = Quaternion.Angle(currentWeapon.GetLaunchRotation(), Quaternion.LookRotation(vectorToTarget, currentWeapon.GetLaunchTransform().up));

						if (angleToTarget <= minimumAttackAngle)
						{
							// If the current weapon fires, cycle to the next one.
							if (_weapons[_weaponFireIndex].TryFire())
							{
								break;
							}
						}
					}

					// Move on to the next weapon to try.
					_weaponFireIndex = (_weaponFireIndex + 1) % _weapons.Count;
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

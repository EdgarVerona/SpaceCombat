using Assets.Scripts.Components.Weapons;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Components.Ships
{
	/// <summary>
	/// All "Ships" that move in space should have these common properties.
	/// </summary>
	public class BaseShip : MonoBehaviour
	{
		public float AccelerationRate;

		public float DecelerationRate;

		public float TurnRate;

		public float PitchRate;

		public float TwistRate;
		
		private WeaponManager _weaponManager;

		private void Start()
		{
			_weaponManager = new WeaponManager(this.gameObject);
		}

		public void FireWeapon()
		{
			_weaponManager.FireWeapon();
		}
	}
}

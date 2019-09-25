using Assets.Components.Ships;
using Assets.Scripts.Components.Weapons;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Scripts.Components.AI
{
	[RequireComponent(typeof(AITargetComponent))]
	public class AIShootingComponent : MonoBehaviour
	{
		public float MinimumAttackAngle = 2.0f;
		public float MinimumDistanceToAttack = 200.0f;

		private float _distanceToPlayer;
		private float _angleToTarget;

		private AITargetComponent _targetComponent;
		private WeaponManager _weaponManager;

		public void Start()
		{
			_targetComponent = this.GetComponent<AITargetComponent>();
			_weaponManager = new WeaponManager(this.gameObject);
		}

		public void FixedUpdate()
		{
			if (_targetComponent.TargetObject != null)
			{
				_weaponManager.FireIfTargetable(_targetComponent.TargetObject, MinimumAttackAngle, MinimumDistanceToAttack);
			}
		}

		public bool ShouldFire()
		{
			return (_distanceToPlayer < this.MinimumDistanceToAttack
				&& _angleToTarget < this.MinimumAttackAngle && _angleToTarget > -this.MinimumAttackAngle);
		}
	}
}

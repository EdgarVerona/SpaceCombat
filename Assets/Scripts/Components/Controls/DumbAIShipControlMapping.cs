using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Assets.Scripts.Components.Controls
{
	public class DumbAIShipControlMapping : BaseShipControlMapping
	{
		public float MinimumAttackAngle = 2.0f;
		public float MinimumDistanceToAttack = 200.0f;
		public float DegreesTurnPerSecond = 25.0f;

		private float _angleToPlayer;
		private float _distanceToPlayer;

		public void FixedUpdate()
		{
			var aPlayer = GameObject.FindGameObjectWithTag("Player");

			if (aPlayer != null)
			{
				var vectorToPlayer = aPlayer.transform.position - this.transform.position;

				var toPlayerUp = Quaternion.LookRotation(vectorToPlayer, Vector3.up);

				// If we're saying we can only rotate 25 degrees in a second, let's use that to interpret how far we should move.
				_angleToPlayer = Quaternion.Angle(this.transform.rotation, toPlayerUp);
				_distanceToPlayer = vectorToPlayer.magnitude;

				this.transform.rotation = Quaternion.Slerp(this.transform.rotation, toPlayerUp, (this.DegreesTurnPerSecond / _angleToPlayer) * Time.fixedDeltaTime);

				//Debug.DrawLine(this.transform.position, aPlayer.transform.position, Color.cyan, 2, false);
				Debug.DrawRay(this.transform.position, vectorToPlayer, Color.red);
				Debug.DrawRay(this.transform.position, vectorToPlayer, Color.cyan);
			}
		}

		public override bool IsAccelerating()
		{
			return false;
		}

		public override bool IsDecelerating()
		{
			return false;
		}

		public override bool IsFirePrimary()
		{
			return (_distanceToPlayer < this.MinimumDistanceToAttack
				&& _angleToPlayer < this.MinimumAttackAngle && _angleToPlayer > -this.MinimumAttackAngle);
		}

		public override bool IsFireSecondary()
		{
			return false;
		}

		public override bool IsLeft()
		{
			return false;
		}

		public override bool IsRight()
		{
			return false;
		}

		public override bool IsTwistLeft()
		{
			return false;
		}

		public override bool IsTwistRight()
		{
			return false;
		}

		public override bool IsDown()
		{
			return false;
		}

		public override bool IsUp()
		{
			return false;
		}
	}
}

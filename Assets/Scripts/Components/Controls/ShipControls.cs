using Assets.Components.Ships;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts.Components.Controls
{
	public class ShipControls : MonoBehaviour
	{
		public Rigidbody RigidBodyToControl;

		public BaseShipControlMapping ControlMapping;

		public BaseShipStats ShipStats;

		void FixedUpdate()
		{
			if (this.ControlMapping.IsAccelerating())
			{
				Debug.Log("Accelerate");
				RigidBodyToControl.transform.position += this.transform.forward * this.ShipStats.AccelerationRate * Time.fixedDeltaTime;
				//RigidBodyToControl.AddRelativeForce(0, 0, this.ShipStats.AccelerationRate * Time.fixedDeltaTime, ForceMode.VelocityChange);
			}
			if (this.ControlMapping.IsDecelerating())
			{
				Debug.Log("Decelerate");
				RigidBodyToControl.transform.position -= this.transform.forward * this.ShipStats.AccelerationRate * Time.fixedDeltaTime;
				//RigidBodyToControl.AddRelativeForce(0, 0, -this.ShipStats.AccelerationRate * Time.fixedDeltaTime, ForceMode.VelocityChange);
			}
			if (this.ControlMapping.IsDown())
			{
				Debug.Log("Down");
				RigidBodyToControl.transform.RotateAround(this.transform.position, this.transform.right, -this.ShipStats.PitchRate * Time.fixedDeltaTime);
			}
			if (this.ControlMapping.IsUp())
			{
				Debug.Log("Up");
				RigidBodyToControl.transform.RotateAround(this.transform.position, this.transform.right, this.ShipStats.PitchRate * Time.fixedDeltaTime);
			}
			if (this.ControlMapping.IsLeft())
			{
				Debug.Log("Left");
				RigidBodyToControl.transform.RotateAround(this.transform.position, this.transform.up, -this.ShipStats.TurnRate * Time.fixedDeltaTime);
			}
			if (this.ControlMapping.IsRight())
			{
				Debug.Log("Right");
				RigidBodyToControl.transform.RotateAround(this.transform.position, this.transform.up, this.ShipStats.TurnRate * Time.fixedDeltaTime);
			}
			if (this.ControlMapping.IsTwistLeft())
			{
				Debug.Log("TwistLeft");
				RigidBodyToControl.transform.RotateAround(this.transform.position, this.transform.forward, -this.ShipStats.TwistRate * Time.fixedDeltaTime);
			}
			if (this.ControlMapping.IsTwistRight())
			{
				Debug.Log("TwistRight");
				RigidBodyToControl.transform.RotateAround(this.transform.position, this.transform.forward, this.ShipStats.TwistRate * Time.fixedDeltaTime);
			}

			if (this.ControlMapping.IsFirePrimary())
			{
				Debug.Log("Fire weapon!");

				this.ShipStats.FireWeapon();
			}
		}
	}
}

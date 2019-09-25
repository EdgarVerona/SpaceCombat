using Assets.Components.Ships;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts.Components.Controls
{
	[RequireComponent(typeof(BaseShip))]
	[RequireComponent(typeof(Rigidbody))]
	[RequireComponent(typeof(BaseShipControlMapping))]
	public class PlayerShipControls : MonoBehaviour
	{
		private Rigidbody _rigidBodyToControl;

		private BaseShipControlMapping _controlMapping;

		private BaseShip _baseShip;

		public void Start()
		{
			_rigidBodyToControl = this.GetComponent<Rigidbody>();
			_controlMapping = this.GetComponent<BaseShipControlMapping>();
			_baseShip = this.GetComponent<BaseShip>();
		}

		void FixedUpdate()
		{
			if (_controlMapping.IsAccelerating())
			{
				Debug.Log("Accelerate");
				_rigidBodyToControl.transform.position += this.transform.forward * _baseShip.AccelerationRate * Time.fixedDeltaTime;
			}
			if (_controlMapping.IsDecelerating())
			{
				Debug.Log("Decelerate");
				_rigidBodyToControl.transform.position -= this.transform.forward * _baseShip.AccelerationRate * Time.fixedDeltaTime;
			}
			if (_controlMapping.IsDown())
			{
				Debug.Log("Down");
				_rigidBodyToControl.transform.RotateAround(this.transform.position, this.transform.right, -_baseShip.PitchRate * Time.fixedDeltaTime);
			}
			if (_controlMapping.IsUp())
			{
				Debug.Log("Up");
				_rigidBodyToControl.transform.RotateAround(this.transform.position, this.transform.right, _baseShip.PitchRate * Time.fixedDeltaTime);
			}
			if (_controlMapping.IsLeft())
			{
				Debug.Log("Left");
				_rigidBodyToControl.transform.RotateAround(this.transform.position, this.transform.up, -_baseShip.TurnRate * Time.fixedDeltaTime);
			}
			if (_controlMapping.IsRight())
			{
				Debug.Log("Right");
				_rigidBodyToControl.transform.RotateAround(this.transform.position, this.transform.up, _baseShip.TurnRate * Time.fixedDeltaTime);
			}
			if (_controlMapping.IsTwistLeft())
			{
				Debug.Log("TwistLeft");
				_rigidBodyToControl.transform.RotateAround(this.transform.position, this.transform.forward, -_baseShip.TwistRate * Time.fixedDeltaTime);
			}
			if (_controlMapping.IsTwistRight())
			{
				Debug.Log("TwistRight");
				_rigidBodyToControl.transform.RotateAround(this.transform.position, this.transform.forward, _baseShip.TwistRate * Time.fixedDeltaTime);
			}

			if (_controlMapping.IsFirePrimary())
			{
				Debug.Log("Fire weapon!");

				_baseShip.FireWeapon();
			}
		}
	}
}

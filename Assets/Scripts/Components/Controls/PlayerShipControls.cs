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
			if (this._controlMapping.IsAccelerating())
			{
				Debug.Log("Accelerate");
				_rigidBodyToControl.transform.position += this.transform.forward * this._baseShip.AccelerationRate * Time.fixedDeltaTime;
			}
			if (this._controlMapping.IsDecelerating())
			{
				Debug.Log("Decelerate");
				_rigidBodyToControl.transform.position -= this.transform.forward * this._baseShip.AccelerationRate * Time.fixedDeltaTime;
			}
			if (this._controlMapping.IsDown())
			{
				Debug.Log("Down");
				_rigidBodyToControl.transform.RotateAround(this.transform.position, this.transform.right, -this._baseShip.PitchRate * Time.fixedDeltaTime);
			}
			if (this._controlMapping.IsUp())
			{
				Debug.Log("Up");
				_rigidBodyToControl.transform.RotateAround(this.transform.position, this.transform.right, this._baseShip.PitchRate * Time.fixedDeltaTime);
			}
			if (this._controlMapping.IsLeft())
			{
				Debug.Log("Left");
				_rigidBodyToControl.transform.RotateAround(this.transform.position, this.transform.up, -this._baseShip.TurnRate * Time.fixedDeltaTime);
			}
			if (this._controlMapping.IsRight())
			{
				Debug.Log("Right");
				_rigidBodyToControl.transform.RotateAround(this.transform.position, this.transform.up, this._baseShip.TurnRate * Time.fixedDeltaTime);
			}
			if (this._controlMapping.IsTwistLeft())
			{
				Debug.Log("TwistLeft");
				_rigidBodyToControl.transform.RotateAround(this.transform.position, this.transform.forward, -this._baseShip.TwistRate * Time.fixedDeltaTime);
			}
			if (this._controlMapping.IsTwistRight())
			{
				Debug.Log("TwistRight");
				_rigidBodyToControl.transform.RotateAround(this.transform.position, this.transform.forward, this._baseShip.TwistRate * Time.fixedDeltaTime);
			}

			if (this._controlMapping.IsFirePrimary())
			{
				Debug.Log("Fire weapon!");

				this._baseShip.FireWeapon();
			}
		}
	}
}

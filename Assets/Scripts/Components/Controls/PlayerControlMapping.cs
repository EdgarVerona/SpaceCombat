using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts.Components.Controls
{
	public class PlayerControlMapping : BaseShipControlMapping
	{
		public KeyCode AccelerateKey = KeyCode.R;

		public KeyCode DecelerateKey = KeyCode.F;

		public KeyCode FirePrimary = KeyCode.UpArrow;

		public KeyCode FireSecondary = KeyCode.DownArrow;

		public KeyCode Left = KeyCode.A;

		public KeyCode Right = KeyCode.D;

		public KeyCode Up = KeyCode.W;

		public KeyCode Down = KeyCode.S;

		public KeyCode TwistLeft = KeyCode.Q;

		public KeyCode TwistRight = KeyCode.E;

		public override bool IsAccelerating()
		{
			return Input.GetKey(this.AccelerateKey);
		}

		public override bool IsDecelerating()
		{
			return Input.GetKey(this.DecelerateKey);
		}

		public override bool IsFirePrimary()
		{
			return Input.GetKey(this.FirePrimary);
		}

		public override bool IsFireSecondary()
		{
			return Input.GetKey(this.FireSecondary);
		}

		public override bool IsLeft()
		{
			return Input.GetKey(this.Left);
		}

		public override bool IsRight()
		{
			return Input.GetKey(this.Right);
		}

		public override bool IsUp()
		{
			return Input.GetKey(this.Up);
		}

		public override bool IsDown()
		{
			return Input.GetKey(this.Down);
		}

		public override bool IsTwistLeft()
		{
			return Input.GetKey(this.TwistLeft);
		}

		public override bool IsTwistRight()
		{
			return Input.GetKey(this.TwistRight);
		}
	}
}


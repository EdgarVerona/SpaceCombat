using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Scripts.Components.Controls
{
	public abstract class BaseShipControlMapping : MonoBehaviour
	{
		public abstract bool IsAccelerating();

		public abstract bool IsDecelerating();

		public abstract bool IsFirePrimary();

		public abstract bool IsFireSecondary();

		public abstract bool IsLeft();

		public abstract bool IsRight();

		public abstract bool IsUp();

		public abstract bool IsDown();

		public abstract bool IsTwistLeft();

		public abstract bool IsTwistRight();
	}
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Scripts.Components.Controls
{
	/// <summary>
	/// $NOTE - I regret this already.  Originally I was picturing that AI and the Player would
	/// have to use the same "controls" for their actions, and the player would have mapping to keyboard
	/// while the AI would have mapping via AI states.  That made AI more complicated than it needed to be
	/// for basic motion.  I need to consider whether this is actually still providing any benefit.
	/// 
	/// Perhaps for automated tests?
	/// </summary>
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

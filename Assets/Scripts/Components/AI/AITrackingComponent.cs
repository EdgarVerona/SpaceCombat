using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Scripts.Components.AI
{
	[RequireComponent(typeof(AITargetComponent))]
	public class AITrackingComponent : MonoBehaviour
	{
		public float DegreesTurnPerSecond = 25.0f;
		
		private AITargetComponent _targetComponent;

		public void Start()
		{
			_targetComponent = this.GetComponent<AITargetComponent>();
		}

		public void FixedUpdate()
		{
			if (_targetComponent != null)
			{
				if (this.transform.rotation != _targetComponent.GetRotationToTarget())
				{
					this.transform.rotation = Quaternion.RotateTowards(this.transform.rotation, _targetComponent.GetRotationToTarget(), this.DegreesTurnPerSecond * Time.fixedDeltaTime);
				}

				// Old way of doing this - turns out there's a convenience method.
				// If we're saying we can only rotate 25 degrees in a second, let's use that to interpret how far we should move.
				// _angleToTarget = Quaternion.Angle(this.transform.rotation, toPlayerUp);
				// this.transform.rotation = Quaternion.Slerp(this.transform.rotation, toPlayerUp, (this.DegreesTurnPerSecond / _angleToTarget) * Time.fixedDeltaTime);
			}
		}
	}
}

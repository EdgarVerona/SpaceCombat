using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Scripts.Components.AI
{
	/// <summary>
	/// IMPORTANT: This component is built with the assumption that roll/pitch/yaw is relative to the entity's Z axis representing "Forward"
	/// </summary>
	[RequireComponent(typeof(AITargetComponent))]
	public class AITrackingSingleAxisComponent : MonoBehaviour
	{
		public bool X;
		public bool Y;
		public bool Z;

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
				Vector3 toTarget = _targetComponent.GetVectorToTarget();

				// World coordinate vector pointing at the target
				toTarget = new Vector3(toTarget.x, toTarget.y, toTarget.z);

				// project into local coordinates, and then cut off axises of rotation?
				var localSpaceTarget = this.transform.InverseTransformVector(toTarget);

				if (!this.X)
				{
					localSpaceTarget.x = 0.0f;
				}
				if (!this.Y)
				{
					localSpaceTarget.y = 0.0f;
				}
				if (!this.Z)
				{
					localSpaceTarget.z = 0.0f;
				}

				toTarget = this.transform.TransformVector(localSpaceTarget);

				var lookTarget = Quaternion.LookRotation(toTarget);

				if (this.transform.rotation != lookTarget)
				{
					this.transform.rotation = Quaternion.RotateTowards(this.transform.rotation, lookTarget, this.DegreesTurnPerSecond * Time.fixedDeltaTime);
				}
			}
		}
	}
}

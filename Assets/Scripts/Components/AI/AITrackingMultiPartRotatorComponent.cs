using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Scripts.Components.AI
{
	/// <summary>
	/// This part depends on the rotation of two separate components to create targeting in 3D space.
	/// 
	/// RollComponent is the component that can be rotated around the Z axis
	/// 
	/// PitchComponent is the component that can be rotated around the X axis
	/// 
	/// Nothing rotates around the Y axis: it depends on combinations of X and Z axis rotations to meet its target.
	/// 
	/// This assumes that "Up" is positive Y axis for all parts, this allows them to be moved in synchronization to create a 3D rotation from the parts.
	/// </summary>
	[RequireComponent(typeof(AITargetComponent))]
	public class AITrackingMultiPartRotatorComponent : MonoBehaviour
	{
		public float DegreesTurnPerSecond = 25.0f;

		public Transform RollComponent;

		public Transform PitchComponent;

		private AITargetComponent _targetComponent;

		private Vector3 _worldVectorRealRoll;

		private Vector3 _worldVectorRealPitch;

		public void Start()
		{
			_targetComponent = this.GetComponent<AITargetComponent>();
		}

		public void FixedUpdate()
		{
			if (_targetComponent != null)
			{
				// First, we have to figure out if we need to roll.  If we do, twist until we get into a position where the Pitch can focus on the enemy.
				var vectorRollToTarget = _targetComponent.TargetObject.transform.position - this.RollComponent.transform.position;

				var vectorRollToTargetLocal = this.RollComponent.transform.InverseTransformVector(vectorRollToTarget);
				vectorRollToTargetLocal.z = 0;
				_worldVectorRealRoll = this.RollComponent.transform.TransformVector(vectorRollToTargetLocal);

				var rollLookRotationTarget = Quaternion.LookRotation(this.RollComponent.forward, _worldVectorRealRoll);

				// Once the roll is correct, move the pitch.
				if (this.RollComponent.rotation == rollLookRotationTarget)
				{
					// Now, figure out if we need to pitch the Pitch component.
					var vectorPitchToTarget = _targetComponent.TargetObject.transform.position - this.PitchComponent.transform.position;

					var vectorPitchToTargetLocal = this.PitchComponent.transform.InverseTransformVector(vectorPitchToTarget);
					vectorPitchToTargetLocal.x = 0;
					_worldVectorRealPitch = this.PitchComponent.transform.TransformVector(vectorPitchToTargetLocal);

					// Slowly pivot to look towards the desired pitch.
					var pitchLookRotationTarget = Quaternion.LookRotation(_worldVectorRealPitch, this.PitchComponent.up);
					this.PitchComponent.rotation = Quaternion.RotateTowards(this.PitchComponent.rotation, pitchLookRotationTarget, this.DegreesTurnPerSecond * Time.fixedDeltaTime);
				}
				else
				{
					// Start the roll rotation toward the target.
					this.RollComponent.rotation = Quaternion.RotateTowards(this.RollComponent.rotation, rollLookRotationTarget, this.DegreesTurnPerSecond * Time.fixedDeltaTime);

					// Set up the pitch component to have the same rotation as the roll.
					// (FLIMY ASSUMPTION: base object roll and pitch components are on same Z axis - think about how we can fix that later)
					this.PitchComponent.rotation = this.RollComponent.rotation;
				}
			}
		}

		public void OnDrawGizmosSelected()
		{
			// Roll vector
			Gizmos.color = Color.red;
			Gizmos.DrawLine(this.RollComponent.position, _worldVectorRealRoll);

			// Pitch vector
			Gizmos.color = Color.blue;
			Gizmos.DrawLine(this.PitchComponent.transform.position, _worldVectorRealPitch);

			// Source to target
			Gizmos.color = Color.yellow;
			Gizmos.DrawLine(this.PitchComponent.position, _targetComponent.TargetObject.transform.position);
		}
	}
}

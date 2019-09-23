using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Scripts.Components.AI
{
	public class AITargetComponent : MonoBehaviour
	{
		public GameObject TargetObject;

		private Vector3 _vectorToTarget = Vector3.zero;
		private Quaternion _rotationToTarget = Quaternion.identity;

		public void SetTarget(GameObject newTarget)
		{
			this.TargetObject = newTarget;
		}

		public void FixedUpdate()
		{
			_vectorToTarget = this.TargetObject.transform.position - this.transform.position;

			_rotationToTarget = Quaternion.LookRotation(_vectorToTarget);
		}

		public void OnDrawGizmosSelected()
		{
			Gizmos.color = Color.cyan;
			Gizmos.DrawRay(this.transform.position, _vectorToTarget);
		}

		public Vector3 GetVectorToTarget()
		{
			return _vectorToTarget;
		}

		public Quaternion GetRotationToTarget()
		{
			return _rotationToTarget;
		}
	}
}

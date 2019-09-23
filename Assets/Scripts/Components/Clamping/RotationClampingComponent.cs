using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Scripts.Components.Clamping
{
	public class RotationClampingComponent : MonoBehaviour
	{
		public float XRotationMin = -360.0f;
		public float XRotationMax = 360.0f;
		public float YRotationMin = -360.0f;
		public float YRotationMax = 360.0f;
		public float ZRotationMin = -360.0f;
		public float ZRotationMax = 360.0f;

		public void LateUpdate()
		{
			this.transform.localRotation = Quaternion.Euler(new Vector3(
				Mathf.Clamp(transform.localRotation.eulerAngles.x, this.XRotationMin, this.XRotationMax),
				Mathf.Clamp(transform.localRotation.eulerAngles.y, this.YRotationMin, this.YRotationMax),
				Mathf.Clamp(transform.localRotation.eulerAngles.z, this.ZRotationMin, this.ZRotationMax)));
		}
	}
}

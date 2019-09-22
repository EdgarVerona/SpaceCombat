using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowCamera : MonoBehaviour
{
	public Transform Target;

	public Vector3 Offset;

    // Update is called once per frame
    void Update()
    {
		this.transform.position = this.Target.position;
		this.transform.rotation = this.Target.rotation;
		this.transform.Translate(this.Offset, Space.Self);
	}
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// $NOTE - At some point, need to make a variant of this that feels more "loose" - it doesn't feel good to have the ship absolutely fixed in a position on the screen even
/// when rolling/pitching.
/// </summary>
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

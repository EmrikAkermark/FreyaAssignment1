using System.Collections;
using System.Collections.Generic;
using UnityEngine;
#if UNITY_EDITOR
using UnityEditor;
#endif

public class LookAtThing : MonoBehaviour
{
	public Transform TrackedObject;
	[Range(0f, 1f)]
	public float LookAtThreshold;

	public float dotProd;
	public Vector2 lookingForward;

#if UNITY_EDITOR
	private void OnDrawGizmos()
	{
		lookingForward  = transform.up;
		Vector2 centre = transform.position;
		Vector2 trackedObjectPos = TrackedObject.position;

		Vector2 VectorTowardsObject = trackedObjectPos - centre;
		VectorTowardsObject.Normalize();

		dotProd = Vector2.Dot(lookingForward, VectorTowardsObject);

		if(dotProd >= LookAtThreshold)
		{
			Handles.color = Color.green;
		}
		else
		{
			Handles.color = Color.red;
		}
		Handles.DrawLine(centre, trackedObjectPos);
		Handles.DrawLine(centre, centre + lookingForward);
	}

#endif
}

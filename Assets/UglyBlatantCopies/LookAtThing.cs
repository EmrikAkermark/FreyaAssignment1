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

#if UNITY_EDITOR
	private void OnDrawGizmos()
	{
		Vector2 lookingForward  = transform.up;
		Vector2 centre = transform.position;
		Vector2 trackedObjectPos = TrackedObject.position;

		Vector2 VectorTowardsObject = trackedObjectPos - centre;

		float dotProduct = Vector2.Dot(lookingForward, VectorTowardsObject);

		if(dotProduct >= LookAtThreshold)
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

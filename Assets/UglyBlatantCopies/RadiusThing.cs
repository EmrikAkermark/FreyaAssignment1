﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
#if UNITY_EDITOR
using UnityEditor;
#endif

public class RadiusThing : MonoBehaviour
{
	public float Radius = 1f;
	public Transform TrackedObject;

#if UNITY_EDITOR
	private void OnDrawGizmos()
	{
		Vector2 centre = transform.position;
		Vector2 trackedObjectPos = TrackedObject.position;

		Vector2 Difference = trackedObjectPos - centre;


		
		Handles.DrawWireDisc(centre, Vector3.forward, Radius);
	}

#endif
}

using System;
using System.Collections;
using System.Collections.Generic;
using NUnit.Framework.Internal;
using UnityEngine;

public class parentScript : MonoBehaviour
{

	public Transform transform;
	public Vector3 parentCenter;
	public Camera mainCamera;
	private float i = 0.0F;

	// Use this for initialization
	void Start () {
		foreach (Transform child in transform)
		{
			child.gameObject.AddComponent<move>();
			child.gameObject.AddComponent<MeshCollider>();
			child.gameObject.AddComponent<Drag_Move>();
			child.gameObject.AddComponent<MouseManager>();
            child.gameObject.AddComponent<Camera_Move>();
		}
		parentCenter = transform.GetComponent<Renderer>().bounds.center;
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}

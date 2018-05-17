using System;
using System.Collections;
using System.Collections.Generic;
using NUnit.Framework.Internal;
using UnityEngine;

public class parentScript : MonoBehaviour
{

	public Transform transform;
	public Vector3 parentCenter;
	private float i = 0.0F;

	// Use this for initialization
	void Start () {
		foreach (Transform child in transform)
			child.gameObject.AddComponent<move>();
		parentCenter = transform.GetComponent<Renderer>().bounds.center;
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}

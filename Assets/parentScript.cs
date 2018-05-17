using System;
using System.Collections;
using System.Collections.Generic;
using NUnit.Framework.Internal;
using UnityEngine;

public class parentScript : MonoBehaviour
{

	public Transform transform;
	private float i = 0.0F;

	// Use this for initialization
	void Start () {
		foreach (Transform child in transform)
		{
			Debug.Log("Child:", child);
			child.gameObject.AddComponent<move>();
			i += 0.25F;
		}
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}

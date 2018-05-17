using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor.Animations;
using UnityEngine;

public class move : MonoBehaviour
{
	public float spread = 1.25F;
	public float smoothTime = 0.3F;
	private Vector3 velocity = Vector3.zero;
	private Vector3 target;
	private Vector3 startPosition;
	private bool flag = false;
	private Vector3 center;
	private Vector3 parentCenter;

	// Use this for initialization
	void Start ()
	{
		center = transform.GetComponent<Renderer>().bounds.center;
		parentCenter = transform.parent.GetComponent<parentScript>().parentCenter;
		target = new Vector3(spread * center.x, spread * center.y, spread * center.z);
		Debug.Log(transform.GetComponent<Renderer>().bounds.center);
		Debug.Log(target);
		startPosition = transform.localPosition;
	}
	
	// Update is called once per frame
	void Update ()
	{
		if (Input.GetKeyDown("a"))
		{
			flag = !flag;
		}

		if (flag == true)
		{
			transform.localPosition = Vector3.SmoothDamp(transform.localPosition, target, ref velocity, smoothTime);	
		}
		else if (flag == false)
		{
			transform.localPosition = Vector3.SmoothDamp(transform.localPosition, startPosition, ref velocity, smoothTime);	
		}
	}
}

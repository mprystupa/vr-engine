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
	private Vector3 startingPosition;
	
	private bool flag = false;
	
	private Vector3 center;
	private Vector3 parentCenter;
	private Vector3 distanceBetweenCenters;

	// Use this for initialization
	void Start ()
	{
		center = transform.GetComponent<Renderer>().bounds.center;
		parentCenter = transform.parent.GetComponent<parentScript>().parentCenter;
		
		distanceBetweenCenters = center - parentCenter;
		target = new Vector3(spread * distanceBetweenCenters.x, spread * distanceBetweenCenters.y,
			spread * distanceBetweenCenters.z);

		startingPosition = transform.localPosition;
//		Debug.Log(transform.GetComponent<Renderer>().bounds.center);
//		Debug.Log(target);
		Debug.Log("Parent Center:" + parentCenter);
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
			transform.localPosition = Vector3.SmoothDamp(transform.localPosition, startingPosition, ref velocity, smoothTime);	
		}
	}
}

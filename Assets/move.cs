using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor.Animations;
using UnityEngine;
using UnityEngine.EventSystems;

public class move : MonoBehaviour
{
	public float spreadSpeed = 1.25F;
	public float smoothTime = 0.3F;
	public float rotationSpeed = 0.1F;
	
	private Vector3 velocity = Vector3.zero;
	public Vector3 target;
	
	private Quaternion startingRotation;
	public Vector3 startingPosition, startingPositionGlobal;
	
	public bool isSpreaded = false;
	private bool isReassembling = false;
	
	private Vector3 center;
	private Vector3 parentCenter;
	private Vector3 distanceBetweenCenters;

	// Use this for initialization
	void Start ()
	{
		center = transform.GetComponent<Renderer>().bounds.center;
		parentCenter = transform.parent.GetComponent<parentScript>().parentCenter;
		
		distanceBetweenCenters = center - parentCenter;
		target = new Vector3(spreadSpeed * distanceBetweenCenters.x, spreadSpeed * distanceBetweenCenters.y,
			spreadSpeed * distanceBetweenCenters.z);

		startingPosition = transform.localPosition;
		startingPositionGlobal = transform.GetComponent<Renderer>().bounds.center;
		startingRotation = transform.localRotation;
	}
	
	// Update is called once per frame
	void Update ()
	{
		if (Input.GetKeyDown("p"))
		{
			isSpreaded = !isSpreaded;
			if (isSpreaded == false) isReassembling = true;
		}

		if (isSpreaded == true)
		{
			transform.localPosition = Vector3.SmoothDamp(transform.localPosition, target, ref velocity, smoothTime);
			transform.localRotation = Quaternion.Lerp(transform.localRotation, startingRotation, rotationSpeed);
		}
		else if (isSpreaded == false)
		{
			if (isReassembling == true)
			{
				transform.localPosition = Vector3.SmoothDamp(transform.localPosition, startingPosition, ref velocity, smoothTime);
				transform.localRotation = Quaternion.Lerp(transform.localRotation, startingRotation, rotationSpeed);
				if (transform.localPosition == startingPosition)
					isReassembling = false;
			}	
		}
	}
}

﻿using UnityEngine;
using System.Collections;

public class PaceBehavior : MonoBehaviour {

	public float PacePeriod = 1.0f;
	public float PaceSpeed = 2.0f;

	private float elapsedTime = 0;
	private Vector3 currentVelocity;
	private Vector3 currentScale;

	// Use this for initialization
	void OnEnable () {
		currentVelocity = new Vector3(-PaceSpeed, 0.0f, 0.0f);
		currentScale = transform.localScale;
		GetComponent<Animator> ().SetFloat ("Speed", 5.0f);
	}

	void OnDisable () {
		GetComponent<Animator> ().SetFloat ("Speed", 0.0f);
	}

	// Update is called once per frame
	void FixedUpdate () {
		elapsedTime += Time.fixedDeltaTime;


		GetComponent<Rigidbody2D>().velocity = currentVelocity;
		transform.localScale = currentScale;

		if(elapsedTime > PacePeriod) {
			currentVelocity.x = -currentVelocity.x;
			currentScale.x = -currentScale.x;
			elapsedTime = 0;
		}
	}
}

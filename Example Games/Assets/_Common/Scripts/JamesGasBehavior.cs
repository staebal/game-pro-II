﻿using UnityEngine;
using System.Collections;

public class JamesGasBehavior : MonoBehaviour {
	
	public bool FlyingAtStart = true;

	private bool FlightMode = false;
	private bool EnableGas = false;

	private ParticleSystem gas;

	private Animator anim;

	// Use this for initialization
	void Start () {
		gas = GetComponentInChildren<ParticleSystem>();
		anim = GetComponent<Animator>();

		if(FlyingAtStart) {
			EnableFlightMode();
		}
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		if(FlightMode) {
			if(GetComponent<Rigidbody2D>().velocity.magnitude > 0) {
				EnableGas = true;
				anim.SetBool("IsFlying", true);
			} else {
				EnableGas = false;
				anim.SetBool("IsFlying", false);
			}

			transform.rotation = Quaternion.Euler(
				new Vector3(0, 0, 
			            Mathf.Rad2Deg * Mathf.Atan2(GetComponent<Rigidbody2D>().velocity.y, GetComponent<Rigidbody2D>().velocity.x)));
		}

		if(EnableGas && !gas.isPlaying) {
			gas.Play();
		} else if(!EnableGas && gas.isPlaying) {
			gas.Stop();
		}
	}

	public void EnableFlightMode() {
		FlightMode = true;
		GetComponent<Animator>().SetBool("IsFlying", true);
		GetComponent<Rigidbody2D>().fixedAngle = false;
		GetComponent<BoxCollider2D>().isTrigger = true;
		GetComponent<Rigidbody2D>().gravityScale = 0;
	}

	public void DisableFlightMode() {
		FlightMode = false;
		EnableGas = false;
		GetComponent<Animator>().SetBool("IsFlying", false);
		GetComponent<Rigidbody2D>().fixedAngle = true;
		GetComponent<BoxCollider2D>().isTrigger = false;
		transform.rotation = Quaternion.identity;
		GetComponent<Rigidbody2D>().gravityScale = 1;
	}
}

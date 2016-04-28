﻿using UnityEngine;
using System.Collections;

public class FireBall_Move : MonoBehaviour {

	// Use this for initialization
	void Start () {

	}

	// Update is called once per frame
	void Update () {
		transform.position -= transform.up * 4 * Time.deltaTime;
	}

	//Collision Check
	void OnCollisionEnter2D(Collision2D other)
	{
		other.gameObject.SendMessage("ApplyDamage", 1);
		Destroy (this.gameObject);
		Destroy (this);
	}
}

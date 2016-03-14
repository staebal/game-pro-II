﻿using UnityEngine;
using System.Collections;

public class ScreenFlasher : MonoBehaviour {

	public float ScreenFlashDuration = 0.1f;

	private float elapsedTime = 0;
	private bool flashScreenNow = false;

	// Update is called once per frame
	void Update () {
		elapsedTime += Time.deltaTime;

		if(flashScreenNow) {
			GetComponent<Renderer>().enabled = true;
			elapsedTime = 0;

			flashScreenNow = false;
		}

		if(elapsedTime > ScreenFlashDuration) {
			GetComponent<Renderer>().enabled = false;
		}
		
	}

	public void FlashScreen() {
		flashScreenNow = true;
	}

}

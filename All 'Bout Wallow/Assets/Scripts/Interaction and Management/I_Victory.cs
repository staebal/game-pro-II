using UnityEngine;
using System.Collections;

public class I_Victory : MonoBehaviour {
	
	// Update is called once per frame
	void Update () {
		// if player presses "Enter" button, go to Intro
		if (Input.GetButtonDown("Submit"))
			GameManager.instance.ChangeToScene("Credits and Thanks");
		// else do nothing
	}
}
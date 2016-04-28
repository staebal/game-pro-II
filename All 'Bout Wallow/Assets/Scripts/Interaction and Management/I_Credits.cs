using UnityEngine;
using System.Collections;

public class I_Credits : MonoBehaviour {
	
	// Update is called once per frame
	void Update () {
		// if player presses "Esc" go to title
		if (Input.GetButtonDown("Cancel"))
			GameManager.instance.ChangeToScene("Title Menu");
		// else do nothing
	}
}

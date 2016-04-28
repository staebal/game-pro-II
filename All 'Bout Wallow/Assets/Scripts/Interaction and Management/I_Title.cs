// http://docs.unity3d.com/410/Documentation/ScriptReference/index.Accessing_Other_Game_Objects.html
// https://unity3d.com/learn/tutorials/projects/2d-roguelike-tutorial/writing-game-manager
using UnityEngine;
using System.Collections;

public class I_Title : MonoBehaviour {
	
	// Update is called once per frame
	void Update () {
		// if player presses "Enter" button, go to Intro
		if (Input.GetButtonDown("Submit")){
			Debug.Log ("Starting New Game!");
			GameManager.instance.ChangeToScene("1.1 Intro");
		}
		// if player presses "c" button go to Credits
		else if (Input.GetKeyDown("c")){
			Debug.Log ("Going to Credits!");
			GameManager.instance.ChangeToScene("Credits and Thanks");
		}
		// if player presses "Esc" button end application
		else if (Input.GetButtonDown("Cancel")){
			Debug.Log ("Quitting App!");
			Application.Quit();
		}
		// else do nothing
	}
}

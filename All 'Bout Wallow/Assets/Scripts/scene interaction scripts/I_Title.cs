// http://docs.unity3d.com/410/Documentation/ScriptReference/index.Accessing_Other_Game_Objects.html
// https://unity3d.com/learn/tutorials/projects/2d-roguelike-tutorial/writing-game-manager
using UnityEngine;
using System.Collections;

public class I_Title : MonoBehaviour {

	GameObject manager;

	// Use this for initialization
	void Start () {
		manager = GameObject.Find("gameManager");
	}
	
	// Update is called once per frame
	void Update () {
		// if player presses start button, go to Intro
		if (){
			manager.GameManager.ChangeToScene("1.1 Intro");
		}
		// if player presses credits button go to Credits
		else if (){
			manager.GameManager.ChangeToScene("Credits and Thanks");
		}
		// if player presses quit button end application
		else if (){
			Application.Quit();
		}
		// else do nothing
	}
}

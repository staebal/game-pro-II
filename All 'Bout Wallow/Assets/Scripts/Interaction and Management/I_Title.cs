// http://docs.unity3d.com/410/Documentation/ScriptReference/index.Accessing_Other_Game_Objects.html
// https://unity3d.com/learn/tutorials/projects/2d-roguelike-tutorial/writing-game-manager
using UnityEngine;
using System.Collections;

public class I_Title : MonoBehaviour {
	
	// Update is called once per frame
	void Update () {
		// if player presses "Enter" button, go to Intro
		if (Input.GetButtonDown("Submit")){
			StartGame ();
		}
		// if player presses "c" button go to Credits
		else if (Input.GetKeyDown("c")){
			Credits ();
		}
		// if player presses "Esc" button end application
		else if (Input.GetButtonDown("Cancel")){
			ExitGame ();
		}
		// else do nothing
	}

	public void ExitGame()
	{
		Debug.Log ("Quitting App!");
		Application.Quit();
	}

	public void StartGame(){
		Debug.Log ("Starting New Game!");
		GameManager.instance.ChangeToScene("1.1 Intro");
	}
	public void TitleMenu(){
		Debug.Log ("Returning to the Title");
		GameManager.instance.ChangeToScene("Title Menu");
	}

	public void Credits(){
		Debug.Log ("Going to Credits!");
		GameManager.instance.ChangeToScene("Credits and Thanks");
	}

	public void Controls(){
		Debug.Log ("Going to Controls!");
		GameManager.instance.ChangeToScene("Controls");
	}
}

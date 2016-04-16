// http://docs.unity3d.com/410/Documentation/ScriptReference/index.Accessing_Other_Game_Objects.html
// https://unity3d.com/learn/tutorials/projects/2d-roguelike-tutorial/writing-game-manager
using UnityEngine;
using System.Collections;

public class I_5PreLion : MonoBehaviour {

	GameObject manager;

	// Use this for initialization
	void Start () {
		manager = GameObject.Find("gameManager");
	}
	
	// Update is called once per frame
	void Update () {
		// if player goes inside big top tent go to 3.1
		if ()
			manager.GameManager.ChangeToScene("3.1 Now Watch Me Whip");
		
		// if player sabotages whip
		if ()
			manager.GameManager.setWhipWasSabotaged(true);
		else
			manager.GameManager.setWhipWasSabotaged(false);
		
		// if player sabotages lion cage
		if ()
			manager.GameManager.setCageWasWelded(true);
		else
			manager.GameManager.setCageWasWelded(false);
	}
}

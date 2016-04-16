// http://docs.unity3d.com/410/Documentation/ScriptReference/index.Accessing_Other_Game_Objects.html
// https://unity3d.com/learn/tutorials/projects/2d-roguelike-tutorial/writing-game-manager
using UnityEngine;
using System.Collections;

public class I_8PreSword : MonoBehaviour {

	GameObject manager;

	// Use this for initialization
	void Start () {
		manager = GameObject.Find("gameManager");
	}
	
	// Update is called once per frame
	void Update () {
		// if player goes inside big top tent go to 4.1
		if ()
			manager.GameManager.ChangeToScene("4.1 Bragging and the Final Bout");
		
		// if player sabotages whip
		if ()
			manager.GameManager.setWhipWasSabotaged(true);
		else
			manager.GameManager.setWhipWasSabotaged(false);
		
		// if player recovers rod
		if
		else
		
		// if player sabotages boots
		if
		else		
	
		// if player replaces knives
		if
		else
		
		// if player wins pre match
		if
		// if sword swallower wins pre match
		else if
	}
}

// http://docs.unity3d.com/410/Documentation/ScriptReference/index.Accessing_Other_Game_Objects.html
// https://unity3d.com/learn/tutorials/projects/2d-roguelike-tutorial/writing-game-manager
using UnityEngine;
using System.Collections;

public class I_4PostFire : MonoBehaviour {

	GameObject manager;

	// Use this for initialization
	void Start () {
		manager = GameObject.Find("gameManager");
	}
	
	// Update is called once per frame
	void Update () {
		// if player goes to bed go to 2.3
		if (){
			manager.GameManager.ChangeToScene("2.3 Gentleman Sabotage");
		}
		// else do nothing
	}
}

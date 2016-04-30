// http://docs.unity3d.com/410/Documentation/ScriptReference/index.Accessing_Other_Game_Objects.html
// https://unity3d.com/learn/tutorials/projects/2d-roguelike-tutorial/writing-game-manager
using UnityEngine;
using System.Collections;

public class I_2PreFire : MonoBehaviour {

	GameObject manager;

	// Use this for initialization
	void Start () {
		manager = GameObject.Find("gameManager");
	}
	
	// Update is called once per frame
	void Update () {
		// if player goes inside big top tent go to 2.1
		if (){
			manager.GameManager.ChangeToScene("2.1 Getting Burned");
		}
		
		// if player eats cake
		if (){
			manager.GameManager.setWallowAteCake(true);
			manager.GameManager.setFireBreatherAteCake(false);
		}
		// if FB eats cake
		else if (){
			manager.GameManager.setWallowAteCake(false);
			manager.GameManager.setFireBreatherAteCake(true);
		}
		// if cake is not eaten
		else if (){
			manager.GameManager.setWallowAteCake(false);
			manager.GameManager.setFireBreatherAteCake(false);
		}
		// else do nothing
	}
}

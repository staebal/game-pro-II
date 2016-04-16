// http://docs.unity3d.com/410/Documentation/ScriptReference/index.Accessing_Other_Game_Objects.html
// https://unity3d.com/learn/tutorials/projects/2d-roguelike-tutorial/writing-game-manager
using UnityEngine;
using System.Collections;

public class I_3FireFight : MonoBehaviour {

	GameObject manager;
	bool wallowWeak;
	bool breatherWeak;
	
	// Use this for initialization
	void Start () {
		manager = GameObject.Find("gameManager");
	
		// determine health debuffs if any
		wallowWeak = manager.GameManager.getWallowAteCake();
		breatherWeak = manager.GameManager.getFireBreatherAteCake();
		if(wallowWeak==true)
			// call debuff function for Wallow health
		else if(breatherWeak==true)
			// call debuff function for FB health
	}
	
	// Update is called once per frame
	void Update () {
		// if player wins fight, go to 2.2
		if (){
			manager.GameManager.ChangeToScene("2.2 Venegence and a Nap");
		}
		// if player loses fight, reset rigs and go to 1.2 (Gameover is not priority now)
		else if (){
			rigReset(1);
			manager.GameManager.ChangeToScene("1.2 Cake and Insults");
		}
		// else do nothing
	}
}

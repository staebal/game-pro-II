// http://docs.unity3d.com/410/Documentation/ScriptReference/index.Accessing_Other_Game_Objects.html
// https://unity3d.com/learn/tutorials/projects/2d-roguelike-tutorial/writing-game-manager
using UnityEngine;
using System.Collections;

public class I_6LionFight : MonoBehaviour {

	GameObject manager;
	bool weakWhip;
	bool noLions;
	
	// Use this for initialization
	void Start () {
		manager = GameObject.Find("gameManager");
	
		// determine rig debuffs if any
		weakWhip = manager.GameManager.getWhipWasSabotaged();
		noLions = manager.GameManager.getCageWasWelded();
		if(weakWhip==true)
			// call debuff function for LT whip
		if(noLions==true)
			// call debuff function for LT lions
	}
	
	// Update is called once per frame
	void Update () {
		// if player wins fight, go to 3.2
		if (){
			manager.GameManager.ChangeToScene("3.2 Mean Look and Rest");
		}
		// if player loses fight, reset rigs and go to 2.3 (Gameover is not priority now)
		else if (){
			rigReset(2);
			manager.GameManager.ChangeToScene("2.3 Gentleman Sabotage");
		}
		// else do nothing
	}
}

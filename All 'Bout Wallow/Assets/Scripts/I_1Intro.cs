﻿// http://docs.unity3d.com/410/Documentation/ScriptReference/index.Accessing_Other_Game_Objects.html
// https://unity3d.com/learn/tutorials/projects/2d-roguelike-tutorial/writing-game-manager
using UnityEngine;
using System.Collections;

public class I_1Intro : MonoBehaviour {

	public GameObject sourcemanager;
    GameManager manager =null;
	// Use this for initialization
	void Start () {
		//manager = GameObject.Find("gameManager");
        manager = sourcemanager.GetComponent<GameManager>();
        if(manager!=null)
        {
            Debug.Log("Found manager object!");
        }
	}
	
	// Update is called once per frame
	void Update () {
		// // if player goes outside wallow's door go to 1.2
		//if (){
		//	manager.ChangeToScene("1.2 Cake and Insults");
		//}
		// else do nothing
	}
    
}
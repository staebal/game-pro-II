// http://docs.unity3d.com/ScriptReference/Debug.Log.html
// http://unity3d.com/learn/tutorials/projects/2d-roguelike-tutorial/writing-game-manager?playlist=17150
using UnityEngine;
using System.Collections;


public class Loader : MonoBehaviour 
{
	public GameObject gameManager;          //GameManager prefab to instantiate.
	
	void Awake ()
	{
		//Check if a GameManager has already been assigned to static variable GameManager.instance or if it's still null
		//Instantiate gameManager prefab
		if (gameManager == null)
			Instantiate(gameManager);
		Debug.Log ("Loader is up!");
	}
}
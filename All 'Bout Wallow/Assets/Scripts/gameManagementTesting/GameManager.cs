// http://unity3d.com/learn/tutorials/projects/2d-roguelike-tutorial/writing-game-manager?playlist=17150

using UnityEngine;
using System.Collections;

    
public class GameManager : MonoBehaviour
{
	public static GameManager instance = null;              // Static instance of GameManager which allows it to be accessed by any other script.
	
	private int sceneIndexNum = 0;
	
	// Awake is always called before any Start functions (UNITY NATIVE)
	void Awake()
	{
		// Check if instance already exists
		// if not, set instance to this
		if (instance == null)
			instance = this;
		// If instance already exists and it's not this:
		// Then destroy this. This enforces our singleton pattern, meaning there can only ever be one instance of a GameManager.
		else if (instance != this)
			Destroy(gameObject);    
		
		// Sets this to not be destroyed when reloading scene
		DontDestroyOnLoad(gameObject);
		
		// call changeScene to set our first scene
		ChangeSecne(sceneIndexNum);
		
	}
	
	// called each time a scene is loaded (UNITY NATIVE)
	void OnLevelWasLoaded()
	{
		// increment scene index number
		sceneIndexNum++;
		// call changeScene to switch our scene
		ChangeSecne(sceneIndexNum);
	}
	
	// creates our current game scene
	void ChangeSecne(int currentScene){
		// call function from scene manager to set up next scene
		//SceneManager.SwitchScene(currentScene);
	}
	
	//Update is called every frame (UNITY NATIVE).
	void Update()
	{
		
	}
}
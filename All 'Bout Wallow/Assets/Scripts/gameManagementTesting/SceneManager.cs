// https://www.youtube.com/watch?v=NY2WB28I_X8
// http://stackoverflow.com/questions/943398/get-int-value-from-enum
// http://forum.unity3d.com/threads/how-to-get-the-loaded-scene-name.86910/
// http://docs.unity3d.com/ScriptReference/SceneManagement.Scene.html
// http://docs.unity3d.com/ScriptReference/SceneManagement.SceneManager.GetActiveScene.html
// http://docs.unity3d.com/ScriptReference/SceneManagement.SceneManager.html
// http://docs.unity3d.com/ScriptReference/GUI.Button.html
// http://answers.unity3d.com/questions/1109497/unity-53-how-to-load-current-level.html
//
using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class SceneManager : MonoBehaviour {

	public bool StartButtonPressed;
	public bool CreditsButtonPressed;
	public bool QuitButtonPressed;
	public bool ReturnButtonPressed;
	public bool ContinueButtonPressed;
	public bool PlayerDied;
	public bool PlayerWon;
    public bool ColliderHit;

	enum SceneLocale {Title, Intro, PreB1, B1, PostB1, PreB2, B2, PostB2, PreB3, B3, Victory, Credits, Dead, Pause};

	//static SceneManager Instance;

	SceneLocale currentSceneNum;
	SceneLocale prevSceneNum;
	
	// Use this for initialization
	void Start () {
		/*
		if(Instance != null){
			GameObject.Destroy(gameObject);
		}
		else{
			GameObject.DontDestroyOnLoad(gameObject);
			Instance = this;
			
			// set the the current scene to title the first time manager is created
            currentSceneNum = SceneLocale.Title;
		}
		*/
		currentSceneNum = (SceneLocale)SceneManager.GetActiveScene().buildIndex;
	}
	
	// Update is called once per frame
	void Update () {
		// check what scene we are currently in
		//prevSceneNum = currentSceneNum;
		//currentSceneNum = (SceneLocale)SceneManager.GetActiveScene().buildIndex;

		// change scenes based on environment changes
        switch (currentSceneNum){
			case SceneLocale.Title:
				// if player presses start button, go to Intro
				if(StartButtonPressed){
					prevSceneNum = currentSceneNum;
					SceneManager.LoadScene((int)SceneLocale.Intro, LoadSceneMode.Single);
				}		
				// if player presses credits button go to Credits
				else if(CreditsButtonPressed){
					prevSceneNum = currentSceneNum;
					SceneManager.LoadScene((int)SceneLocale.Credits, LoadSceneMode.Single);
				}		
				// if player presses quit button end application
				else if(QuitButtonPressed){
                    prevSceneNum = currentSceneNum;
                    // quit code?
                }	
				// else do nothing
				break;
			case SceneLocale.Intro:
                // if player goes outside wallow's door go to PreB1
                if (ColliderHit){
					prevSceneNum = currentSceneNum;
					SceneManager.LoadScene((int)SceneLocale.PreB1, LoadSceneMode.Single);
                } 
				// else do nothing
				break;
			case SceneLocale.PreB1: 
				// if player goes inside big top tent go to B1
				if (ColliderHit){
					prevSceneNum = currentSceneNum;
					SceneManager.LoadScene((int)SceneLocale.B1, LoadSceneMode.Single);
                } 
				// else do nothing
				break;
			case SceneLocale.B1:
				// if player wins fight, go to PostB1
				if (PlayerWon){
					
					prevSceneNum = currentSceneNum;
					SceneManager.LoadScene((int)SceneLocale.PostB1, LoadSceneMode.Single);
                } 
				// if player loses fight, go to Dead
				else if (PlayerDied){
					prevSceneNum = currentSceneNum;
					SceneManager.LoadScene((int)SceneLocale.Dead, LoadSceneMode.Single);
				}
				// else do nothing
				break;
			case SceneLocale.PostB1:
				// if player goes to rest on wallow's bed go to PreB2
				if (ColliderHit){
					prevSceneNum = currentSceneNum;
					SceneManager.LoadScene((int)SceneLocale.PreB2, LoadSceneMode.Single);
                } 
				// else do nothing			
				break;
			case SceneLocale.PreB2: 
				// if player goes inside big top tent go to B2
				if (ColliderHit){
					prevSceneNum = currentSceneNum;
					SceneManager.LoadScene((int)SceneLocale.B2, LoadSceneMode.Single);
                } 
				// else do nothing
				break;
			case SceneLocale.B2: 
				// if player wins fight, go to PostB2
				if (PlayerWon){
					
					prevSceneNum = currentSceneNum;
					SceneManager.LoadScene((int)SceneLocale.PostB2, LoadSceneMode.Single);
                } 
				// if player loses fight, go to Dead
				else if (PlayerDied){
					prevSceneNum = currentSceneNum;
					SceneManager.LoadScene((int)SceneLocale.Dead, LoadSceneMode.Single);
				}
				// else do nothing
				break;
			case SceneLocale.PostB2:
				// if player goes to rest on wallow's bed go to PreB3	
				if (ColliderHit){
					prevSceneNum = currentSceneNum;
					SceneManager.LoadScene((int)SceneLocale.PreB3, LoadSceneMode.Single);
                } 				
				// else do nothing
				break;
			case SceneLocale.PreB3:
				// if player goes inside big top tent go to B3
				if (ColliderHit){
					prevSceneNum = currentSceneNum;
					SceneManager.LoadScene((int)SceneLocale.B3, LoadSceneMode.Single);
                } 
				// else do nothing
				break;
			case SceneLocale.B3: 
				// if player wins fight, go to Victory
				if (PlayerWon){	
					prevSceneNum = currentSceneNum;
					SceneManager.LoadScene((int)SceneLocale.Victory, LoadSceneMode.Single);
                } 
				// if player loses fight, go to Dead
				else if (PlayerDied){
					prevSceneNum = currentSceneNum;
					SceneManager.LoadScene((int)SceneLocale.Dead, LoadSceneMode.Single);
				}
				// else do nothing
				break;
			case SceneLocale.Victory:
				// if player hits "Credits" go to Credits
				else if(CreditsButtonPressed){
					prevSceneNum = currentSceneNum;
					SceneManager.LoadScene((int)SceneLocale.Credits, LoadSceneMode.Single);
				}		
				// else do nothing
				break;
			case SceneLocale.Credits:
				// if player hits "Return to Tile" go to Title
				if(ReturnButtonPressed){
					prevSceneNum = currentSceneNum;
					SceneManager.LoadScene((int)SceneLocale.Title, LoadSceneMode.Single);
				}		
				// else do nothing
				break;
			case SceneLocale.Dead:
				// if player hits "Continue"
				if(ContinueButtonPressed){
					// if prevScene was B1 go to PreB1
					if(prevSceneNum==SceneLocale.B1){
						prevSceneNum = currentSceneNum;
						SceneManager.LoadScene((int)SceneLocale.Title, LoadSceneMode.Single);
					}
					// if prevScene was B2 go to PreB2
					else if(prevSceneNum==SceneLocale.B2){
						prevSceneNum = currentSceneNum;
						SceneManager.LoadScene((int)SceneLocale.Title, LoadSceneMode.Single);
					}
					// if prevScene was B3 go to PreB3
					else if(prevSceneNum==SceneLocale.B3){
						prevSceneNum = currentSceneNum;
						SceneManager.LoadScene((int)SceneLocale.Title, LoadSceneMode.Single);
					}
				}
				// if player hits "Return to Title" go to Title
				if(ReturnButtonPressed){
					prevSceneNum = currentSceneNum;
					SceneManager.LoadScene((int)SceneLocale.Title, LoadSceneMode.Single);
				}
				// else do nothing
				break;
			case SceneLocale.Pause:
				// if player  hits "Continue", go back to previous scene
				// if player hits "Return to Title" go to Title
				// else do nothing
				break;
		}
	}
}

// http://unity3d.com/learn/tutorials/projects/2d-roguelike-tutorial/writing-game-manager?playlist=17150
// https://www.youtube.com/watch?v=NY2WB28I_X8
// http://www.fizixstudios.com/labs/do/view/id/unity-game-state-manager
using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
    
public class GameManager : MonoBehaviour{
	public static GameManager instance = null;              // Static instance of GameManager which allows it to be accessed by any other script.
	public GameObject CommonQuartersMusic =null;
	public GameObject CarnivalGroundsMusic=null;
	public GameObject FireBreatherMusic=null;
	public GameObject LionTamerMusic=null;
	public GameObject SwordSwallowerMusic=null;
	public GameObject CreditsMusic=null;
	public GameObject MenuMusic=null;
	//private int currentSceneIndexInt;
	
	private bool wallowAteCake				= false;
	private bool fireBreatherAteCake		= false;
	private bool whipWasSabotaged			= false;
	private bool cageWasWelded				= false;
	private bool rodWasStolen				= true;
	private bool bootsWereSabotaged			= false;
	private bool knivesWereReplaced			= false;
	private bool wallowLostPreMatch			= false;
	private bool swordSwallowerLostPreMatch	= false;
	private string lastScene;
	
	
	//enum SceneLocale {Title, Intro, PreB1, B1, PostB1, PreB2, B2, PostB2, PreB3, B3, Victory, Credits, Dead, Pause};
	
	// Awake is always called before any Start functions (UNITY NATIVE)
	void Awake(){
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
		lastScene = SceneManager.GetActiveScene ().name;

	}
	
	// creates target game scene
	public void ChangeToScene(string targetSceneString){
		// call function from scene manager to set up next scene
		//SwitchScene(targetSceneString);
		SceneManager.LoadScene(targetSceneString, LoadSceneMode.Single);
		ChangeSceneMusic(targetSceneString);
	} 

	public void ChangeSceneMusic(string SceneName)
	{
		print (SceneName);
		switch (SceneName) {
		//carnival grounds music
		case "1.4 Liontamer Setup":
		case "2.2 Vengeance and a Nap":
		case "2.5 Lion Cages Rigging":
		case "3.3 Liontamer's Lament":
			FireBreatherMusic.SetActive (false);
			CommonQuartersMusic.SetActive (false);
			CarnivalGroundsMusic.SetActive (true);
			LionTamerMusic.SetActive (false);
			SwordSwallowerMusic.SetActive (false);
			CreditsMusic.SetActive (false);
			MenuMusic.SetActive (false);
			break;
			//Firebreather fight music
		case "2.1 Getting Burned":
			FireBreatherMusic.SetActive (true);
			CommonQuartersMusic.SetActive (false);
			CarnivalGroundsMusic.SetActive (false);
			LionTamerMusic.SetActive (false);
			SwordSwallowerMusic.SetActive (false);
			CreditsMusic.SetActive (false);
			MenuMusic.SetActive (false);
			break;
			//Liontamer fight music
		case "3.1 Now Watch Me Whip":
			FireBreatherMusic.SetActive (false);
			CommonQuartersMusic.SetActive (false);
			CarnivalGroundsMusic.SetActive (false);
			LionTamerMusic.SetActive (true);
			SwordSwallowerMusic.SetActive (false);
			CreditsMusic.SetActive (false);
			MenuMusic.SetActive (false);
			break;
			//Swordswallower fight music
		case "4.1 Bragging and the Final Bout":
			FireBreatherMusic.SetActive (false);
			CommonQuartersMusic.SetActive (false);
			CarnivalGroundsMusic.SetActive (false);
			LionTamerMusic.SetActive (false);
			SwordSwallowerMusic.SetActive (true);
			CreditsMusic.SetActive (false);
			MenuMusic.SetActive (false);
			break;
			//credits music
		case "Credits and Thanks":
			FireBreatherMusic.SetActive (false);
			CommonQuartersMusic.SetActive (false);
			CarnivalGroundsMusic.SetActive (false);
			LionTamerMusic.SetActive (false);
			SwordSwallowerMusic.SetActive (false);
			CreditsMusic.SetActive (true);
			MenuMusic.SetActive (false);
			break;
		case "Title Menu":
		case "Pause Menu":
		case "Game Over":
			FireBreatherMusic.SetActive (false);
			CommonQuartersMusic.SetActive (false);
			CarnivalGroundsMusic.SetActive (false);
			LionTamerMusic.SetActive (false);
			SwordSwallowerMusic.SetActive (false);
			CreditsMusic.SetActive (false);
			MenuMusic.SetActive (true);
			break;
			//epilogue no music
		case "Victory and Epilogue":
			FireBreatherMusic.SetActive (false);
			CommonQuartersMusic.SetActive (false);
			CarnivalGroundsMusic.SetActive (false);
			LionTamerMusic.SetActive (false);
			SwordSwallowerMusic.SetActive (false);
			CreditsMusic.SetActive (false);
			MenuMusic.SetActive (false);
			break;
			//common areas music
		default:
			CommonQuartersMusic.SetActive (true);
			CarnivalGroundsMusic.SetActive (false);
			FireBreatherMusic.SetActive (false);
			LionTamerMusic.SetActive (false);
			SwordSwallowerMusic.SetActive (false);
			CreditsMusic.SetActive (false);
			MenuMusic.SetActive (false);
			break;
		}
	}
	//void SwitchScene(string targetSceneString){
	//	SceneManager.LoadScene(targetSceneString, LoadSceneMode.Single);
	//}
	
	// creates target game scene
	//public void ChangeToScene(int targetSceneIndex){
		// call function from scene manager to set up next scene
	//	SwitchScene(targetSceneIndex);
		// update current scene var
	//	currentSceneIndexInt = targetSceneIndex;
	//}
	
	// creates next game scene
	//public void incrementScene(){
		// call function from scene manager to set up next scene
	//	SwitchScene(currentSceneIndexInt+1);
		// update current scene var
	//	currentSceneIndexInt++;		
	//}
	
	// loads the requested game scene
	//void SwitchScene(int targetSceneIndex){
		//SceneLocale currentSceneIndex = (SceneLocale)SceneManager.GetActiveScene().buildIndex;
		// SceneLocale targetLocale = (SceneLocale)targetSceneIndex;
		
		// change scenes based on environment changes
        // switch (targetLocale){
			// case SceneLocale.Title:		SceneManager.LoadScene((int)SceneLocale.Title, LoadSceneMode.Single);
										// break;
			// case SceneLocale.Intro:		SceneManager.LoadScene((int)SceneLocale.Intro, LoadSceneMode.Single);
										// break;
			// case SceneLocale.PreB1: 	SceneManager.LoadScene((int)SceneLocale.PreB1, LoadSceneMode.Single);
										// break;
			// case SceneLocale.B1:		SceneManager.LoadScene((int)SceneLocale.B1, LoadSceneMode.Single);
										// break;
			// case SceneLocale.PostB1:	SceneManager.LoadScene((int)SceneLocale.PostB1, LoadSceneMode.Single);
										// break;
			// case SceneLocale.PreB2: 	SceneManager.LoadScene((int)SceneLocale.PreB2, LoadSceneMode.Single);
										// break;
			// case SceneLocale.B2: 		SceneManager.LoadScene((int)SceneLocale.B2, LoadSceneMode.Single);
										// break;
			// case SceneLocale.PostB2:	SceneManager.LoadScene((int)SceneLocale.PostB2, LoadSceneMode.Single);
										// break;
			// case SceneLocale.PreB3:		SceneManager.LoadScene((int)SceneLocale.PreB3, LoadSceneMode.Single);
										// break;
			// case SceneLocale.B3: 		SceneManager.LoadScene((int)SceneLocale.B3, LoadSceneMode.Single);
										// break;
			// case SceneLocale.Victory:	SceneManager.LoadScene((int)SceneLocale.Victory, LoadSceneMode.Single);
										// break;
			// case SceneLocale.Credits:	SceneManager.LoadScene((int)SceneLocale.Credits, LoadSceneMode.Single);
										// break;
			// case SceneLocale.Dead:		SceneManager.LoadScene((int)SceneLocale.Dead, LoadSceneMode.Single);
										// break;
			// case SceneLocale.Pause:		SceneManager.LoadScene((int)SceneLocale.Pause, LoadSceneMode.Single);
										// break;
		// }
	//}
	
	//rigging boolean getters and setters
	public bool getWallowAteCake(){
		return wallowAteCake;
	}
	public void setWallowAteCake(bool choice){
		wallowAteCake = choice;
	}
	//
	public bool getFireBreatherAteCake(){
		return fireBreatherAteCake;
	}
	public void setFireBreatherAteCake(bool choice){
		fireBreatherAteCake = choice;
	}
	//
	public bool getWhipWasSabotaged(){
		return whipWasSabotaged;
	}
	public void setWhipWasSabotaged(bool choice){
		whipWasSabotaged = choice;
	}
	//
	public bool getCageWasWelded(){
		return cageWasWelded;
	}
	public void setCageWasWelded(bool choice){
		cageWasWelded = choice;
	}
	//	
	public bool getRodWasStolen(){
		return rodWasStolen;
	}
	public void setRodWasStolen(bool choice){
		rodWasStolen = choice;
	}
	//
	public bool getBootsWereSabotaged(){
		return bootsWereSabotaged;
	}
	public void setBootsWereSabotaged(bool choice){
		bootsWereSabotaged = choice;
	}
	//
	public bool getKnivesWereReplaced(){
		return knivesWereReplaced;
	}
	public void setKnivesWereReplaced(bool choice){
		knivesWereReplaced = choice;
	}
	//
	public bool getWallowLostPreMatch(){
		return wallowLostPreMatch;
	}
	public void setWallowLostPreMatch(bool choice){
		wallowLostPreMatch = choice;
	}	
	//
	public bool getSwordSwallowerLostPreMatch(){
		return swordSwallowerLostPreMatch;
	}
	public void setSwordSwallowerLostPreMatch(bool choice){
		swordSwallowerLostPreMatch = choice;
	}	
	
	// rigging reset method (if wallow "dies" in a fight)
	public void rigReset(int fightNumber){
		switch (fightNumber){
			case 3:	rodWasStolen 				= true;
					bootsWereSabotaged 			= false;
					knivesWereReplaced 			= false;
					wallowLostPreMatch 			= false;
					swordSwallowerLostPreMatch 	= false;
					break;
			case 2:	whipWasSabotaged 	= false;
					cageWasWelded 		= false;
					break;
			case 1:	wallowAteCake 		= false;
					fireBreatherAteCake	= false;
					break;
		}
	}

	void Update(){
		if (SceneManager.GetActiveScene ().name != lastScene) {
			print ("doot!");
			ChangeSceneMusic (SceneManager.GetActiveScene ().name);
			lastScene = SceneManager.GetActiveScene ().name;
		}
	}
}
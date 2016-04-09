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

public class testTransitions : MonoBehaviour {

	int prevScene;
	int curScene;
	

	void Start () {
		curScene = SceneManager.GetActiveScene().buildIndex;
	}
	
	// Update is called once per frame
	void Update () {

	}
}

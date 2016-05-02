using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class ExitScene : MonoBehaviour {
    public string exitScene;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.tag == "Player")
        {
            GameManager.instance.ChangeToScene(exitScene);
        }
    }
}

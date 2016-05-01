using UnityEngine;
using System.Collections;

public class FireRodTaken : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
    void OnCollisionEnter2D(Collision2D other)
    {
		if(other.gameObject.tag == "Player"){
			if(GameManager.instance)
				GameManager.instance.setRodWasStolen(false);
			this.gameObject.SetActive(false);
		}
	}
}

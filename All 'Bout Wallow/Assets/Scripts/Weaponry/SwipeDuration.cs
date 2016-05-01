// http://unity3d.com/learn/tutorials/projects/space-shooter/shooting-shots?playlist=17147

using UnityEngine;
using System.Collections;

public class SwipeDuration : MonoBehaviour {

	// the starting time of swipe creation
	private int swipeTimer;
	
	// Use this for initialization
	void Start () {
		swipeTimer = 5;
	}
	
	// Update is called once per frame
	void Update () {
		swipeTimer--;
		// check current swipe time
		if(swipeTimer<=0){	
			// destroy object instance after x time of being alive
			Destroy(gameObject);
		}
	}

	//Collision Check
	void OnCollisionEnter2D(Collision2D other)
	{
		//Debug.Log ("Wallow inflicted sword damage!");
		if (other.gameObject.tag == "Boss" || other.gameObject.tag == "WhipRest" || other.gameObject.tag == "Boots") {
			other.gameObject.SendMessage("ApplyDamage", 1, SendMessageOptions.DontRequireReceiver);
		}
		if (other.gameObject.tag != "Player"){
			Destroy (this.gameObject);
			Destroy (this);
		}

	}
}

// http://unity3d.com/learn/tutorials/projects/space-shooter/shooting-shots?playlist=17147

using UnityEngine;
using System.Collections;

public class SwipeDuration : MonoBehaviour {

	// the starting time of swipe creation
	public float swipeTimer=0.45f;
	
	// Use this for initialization
	void Start () {
		Destroy(gameObject,swipeTimer);
	}

	//Collision Check
	void OnTriggerStay2D(Collider2D other)
	{
		if (other.gameObject.tag == "Boss" || other.gameObject.tag == "WhipRest" || other.gameObject.tag == "Boots") {
			other.gameObject.SendMessage ("ApplyDamage", 1, SendMessageOptions.DontRequireReceiver);
		} else {
			other.gameObject.SendMessage ("SwipeDamage", 1, SendMessageOptions.DontRequireReceiver);
		}
		if(other.gameObject.tag!="Player")
		Destroy(gameObject);
	}
}

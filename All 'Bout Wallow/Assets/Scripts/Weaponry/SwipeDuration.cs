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
	void OnCollisionStay2D(Collision2D other)
	{
		if (other.gameObject.tag == "Boss") {
			other.gameObject.SendMessage ("ApplyDamage", 1);
		} else {
			other.gameObject.SendMessage ("SwipeDamage", 1);
		}
		Destroy(gameObject);
	}
}

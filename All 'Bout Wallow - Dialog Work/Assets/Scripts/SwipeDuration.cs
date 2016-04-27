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
}

// http://unity3d.com/learn/tutorials/projects/space-shooter/shooting-shots?playlist=17147

using UnityEngine;
using System.Collections;

public class SwipeDuration : MonoBehaviour {

	// time the swipe remains on screen
	public float aliveTime;

	GameObject gObj;

	// the starting time of swipe creation
	private float startTime;
	
	// Use this for initialization
	void Start () {
		gObj = GetComponent<GameObject> ();
		startTime = Time.time;
	}
	
	// Update is called once per frame
	void Update () {
		// check difference between starting and current time
		while(Time.time-startTime < aliveTime){	
			// waiting loop
		}
		// destroy object instance after x time of being alive
		Destroy(gObj);
	}
}

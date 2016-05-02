using UnityEngine;
using System.Collections;

public class CreditsSwap : MonoBehaviour {
	public GameObject[] items=new GameObject[5];
	public float creditduration=0.5f;
	// Use this for initialization
	int position=0;
	float lastcall;
	void Start () {
		foreach(var item in items)
		{
			item.SetActive (false);
		}
		lastcall = Time.time;
		items[0].SetActive (true);
	}
	
	// Update is called once per frame
	void Update () {
		if ( Time.time-lastcall  >= creditduration) {
			items [position++].SetActive (false);
			if (position < items.Length) {
				items [position].SetActive (true);
			} else {
				position = 0;
			}
			lastcall = Time.time;
		}
	}
}

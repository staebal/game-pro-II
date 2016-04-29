using UnityEngine;
using System.Collections;

public class Whip_Move : MonoBehaviour {

	int flashtimer;
	bool whipsab;

	// Use this for initialization
	void Start () {
		whipsab = false;
		flashtimer = 60;
		//here is where you load the whipsab from the header
	}

	// Update is called once per frame
	void Update () {
		flashtimer--;
		if (flashtimer <= 0) {
			Destroy (this.gameObject);
			Destroy (this);
		}
	}

	//Collision Check
	void OnCollisionEnter2D(Collision2D other)
	{
		if (!whipsab) {
			other.gameObject.SendMessage ("ApplyDamage", 2, SendMessageOptions.DontRequireReceiver);
		} else {
			other.gameObject.SendMessage ("ApplyDamage", 1, SendMessageOptions.DontRequireReceiver);
		}
		Destroy (this.gameObject);
		Destroy (this);
	}
}

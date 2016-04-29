using UnityEngine;
using System.Collections;

public class FireWall_Move : MonoBehaviour {

	int flashtimer;

	// Use this for initialization
	void Start () {
		flashtimer = 60;
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
		other.gameObject.SendMessage("ApplyDamage", 2, SendMessageOptions.DontRequireReceiver);
		Destroy (this.gameObject);
		Destroy (this);
	}
}

using UnityEngine;
using System.Collections;

public class WallowWhip_Move : MonoBehaviour {

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
		if (other.gameObject.tag == "Boss") {
			if (!whipsab) {
				other.gameObject.SendMessage ("ApplyDamage", 2);
			} else {
				other.gameObject.SendMessage ("ApplyDamage", 1);
			}
		} else {
			if (!whipsab) {
				other.gameObject.SendMessage ("WhipDamage", 2);
			} else {
				other.gameObject.SendMessage ("WhipDamage", 1);
			}
		}
		Destroy (this.gameObject);
		Destroy (this);
	}
}

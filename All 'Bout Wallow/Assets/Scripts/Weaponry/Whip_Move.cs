using UnityEngine;
using System.Collections;

public class Whip_Move : MonoBehaviour {

	int flashtimer;
	bool whipsab;

	// Use this for initialization
	void Start () {
		whipsab = GameManager.instance.getWhipWasSabotaged();
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
		int damage;
		if (!whipsab) {
			damage = 2;
		} else {
			damage = 1;
		}
		
		if (other.gameObject.tag == "Boss" || other.gameObject.tag == "Bucket"){
			other.gameObject.SendMessage ("ApplyDamage", damage, SendMessageOptions.DontRequireReceiver);
		}
		if (other.gameObject.tag != "Player"){
			Destroy (this.gameObject);
			Destroy (this);
		}
	}
}

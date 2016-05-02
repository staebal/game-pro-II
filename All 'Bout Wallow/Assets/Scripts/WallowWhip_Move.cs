using UnityEngine;
using System.Collections;

public class WallowWhip_Move : MonoBehaviour {

	public float flashtimer=0.1f;
	bool whipsab;

	// Use this for initialization
	void Start () {
		if(GameManager.instance!=null)
		whipsab = GameManager.instance.getWhipWasSabotaged();
		Destroy (gameObject, flashtimer);
		//here is where you load the whipsab from the header
	}

	// Update is called once per frame
	void Update () {

	}

	//Collision Check
	void OnCollisionEnter2D(Collision2D other)
	{
		if (other.gameObject.tag == "Boss") {
			if (!whipsab) {
				other.gameObject.SendMessage ("ApplyDamage", 2, SendMessageOptions.DontRequireReceiver);
			} else {
				other.gameObject.SendMessage ("ApplyDamage", 1, SendMessageOptions.DontRequireReceiver);
			}
		} else {
			if (!whipsab) {
				other.gameObject.SendMessage ("WhipDamage", 2, SendMessageOptions.DontRequireReceiver);
			} else {
				other.gameObject.SendMessage ("WhipDamage", 1, SendMessageOptions.DontRequireReceiver);
			}
		}
	/*	if(other.gameObject.tag!="Player")
		Destroy (gameObject);*/
	}
}

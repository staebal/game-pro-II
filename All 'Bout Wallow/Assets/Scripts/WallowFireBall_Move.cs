using UnityEngine;
using System.Collections;

public class WallowFireBall_Move : MonoBehaviour {

	// Use this for initialization
	void Start () {

	}

	// Update is called once per frame
	void Update () {
		transform.Translate (new Vector3 (4 * Time.deltaTime, 0, 0));
	}

	//Collision Check
	void OnCollisionEnter2D(Collision2D other)
	{
		if (other.gameObject.Tag == "Boss") {
			other.gameObject.SendMessage ("ApplyDamage", 1);
		} else {
			other.gameObject.SendMessage("Weld", 1);
		}
		Destroy (this.gameObject);
		Destroy (this);
	}
}

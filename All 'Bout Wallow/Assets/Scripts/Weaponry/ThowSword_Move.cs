using UnityEngine;
using System.Collections;

public class ThowSword_Move : MonoBehaviour {

	Transform target; //target Wallow
	int life;

	// Use this for initialization
	void Start () {
		//Target Wallow
		target = GameObject.FindWithTag("Player").transform; //target the player
		transform.LookAt (target.position);
		transform.Rotate (new Vector3 (0, -90, 0), Space.Self);
		life = 0;
	}

	// Update is called once per frame
	void Update () {
		life++;
		if (life >= 400) {
			Destroy (this.gameObject);
			Destroy (this);
		}
		transform.Translate (new Vector3 (4 * Time.deltaTime, 0, 0));
	}

	//Collision Check
	void OnCollisionEnter2D(Collision2D other)
	{
		other.gameObject.SendMessage("ApplyDamage", 1);
		Destroy (this.gameObject);
		Destroy (this);
	}
}

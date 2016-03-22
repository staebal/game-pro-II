using UnityEngine;
using System.Collections;

public class ThrowSword_Move : MonoBehaviour {

	Transform target; //target Wallow

	// Use this for initialization
	void Start () {
		//Target Wallow
		target = GameObject.FindWithTag("Player").transform; //target the player
		transform.LookAt (target.position);
		transform.Rotate (new Vector3 (0, -90, 0), Space.Self);
	}
	
	// Update is called once per frame
	void Update () {
		transform.Translate (new Vector3(4 * Time.deltaTime, 0, 0));
	}

	//Collision Check
	void OnCollisionEnter2D(Collision2D other)
	{
		Destroy (this.gameObject);
	}
}

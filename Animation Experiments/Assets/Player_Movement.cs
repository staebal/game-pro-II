using UnityEngine;
using System.Collections;

public class Player_Movement : MonoBehaviour {

	Rigidbody2D rbody;
	Animator anim;

	// Use this for initialization
	void Start () {
		rbody = GetComponent<Rigidbody2D> ();
		anim = GetComponent<Animator> ();
	}
	
	// Update is called once per frame
	void Update () {

		Vector2 movement_vector = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
		if (movement_vector != Vector2.zero) {
			anim.SetBool ("Is_Walking", true);
			anim.SetFloat ("Input_X", movement_vector.x);
			anim.SetFloat ("Input_Y", movement_vector.y);
		} else {
			anim.SetBool ("Is_Walking", false);
		}
		rbody.MovePosition (rbody.position + movement_vector * 3 * Time.deltaTime);
	}

	//Collision Check
	void OnCollisionEnter2D(Collision2D other)
	{
		other.gameObject.SendMessage ("ApplyDamage", 10);
	}
}

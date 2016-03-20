using UnityEngine;
using System.Collections;

public class Mover : MonoBehaviour {

	public float speed;
	Rigidbody2D rBody;
	Animator animator;

	// Use this for initialization
	void Start () {
		rBody = GetComponent<Rigidbody2D> ();
		animator = GetComponent<Animator> ();
	}
	
	// use this once per frame
	void Update () {
		// Prehaps upgrade to utilize .GetAxis()???
		Vector2 movementVector = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
		if(movementVector != Vector2.zero) {		// if moving
			animator.SetBool("IsMoving", true);
			animator.SetFloat("InputX", movementVector.x);
			animator.SetFloat("InputY", movementVector.y);
		}
		else {										// if not moving
			animator.SetBool("IsMoving", false);
		}
		
		// Prehaps ugrade to utilize FixedUpdate()?
		rBody.MovePosition(rBody.position + movementVector * speed * Time.deltaTime);
		
	}
	
	//void FixedUpdate () {
		//var mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
		//Quaternion rot = Quaternion.LookRotation(transform.position - mousePosition, Vector3.forward);
		//Quaternion rot = Quaternion.LookRotation(transform.position - mousePosition);
	
		//transform.rotation = rot;
		//transform.eulerAngles = new Vector3(0, 0, transform.eulerAngles.z);
		//GetComponent<Rigidbody2D>().angularVelocity = 0;
		
		//float input = Input.GetAxisRaw("Vertical");
		//GetComponent<Rigidbody2D>().AddForce(gameObject.transform.up * speed * input);
		
		//if(Event.current.Equals(Event.KeyboardEvent("w"))){
		//}
		//Input.GetAxisRaw("Horizontal");
		//Input.GetAxisRaw("Vertical");
	//}
}
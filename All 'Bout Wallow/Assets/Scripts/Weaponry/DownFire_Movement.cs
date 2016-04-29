using UnityEngine;
using System.Collections;

public class DownFire_Movement : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		transform.position -= transform.up * 4 * Time.deltaTime;
	}

	//Collision Check
	void OnCollisionEnter2D(Collision2D other)
	{
		Destroy (this.gameObject);
		Destroy (this);
	}
}

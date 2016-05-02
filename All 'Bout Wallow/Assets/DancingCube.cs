using UnityEngine;
using System.Collections;

public class DancingCube : MonoBehaviour {
	public Vector2 position;
	public float speed=0.01f;
	Vector2 startpos;
	bool atpos;
	// Use this for initialization
	void Start () {
		//position=new Vector2 (7, 0);
		atpos = false;
		startpos = transform.position;
	}
	
	// Update is called once per frame
	void Update () {
		
		if (((Vector2)transform.position - position == Vector2.zero)&&!atpos) {
			atpos = true;
		}
		if (((Vector2)transform.position - startpos == Vector2.zero)&&atpos) {
			atpos = false;
		}
		if (atpos) {
			transform.position = Vector2.MoveTowards (transform.position, startpos, speed);
		} else {
			transform.position = Vector2.MoveTowards (transform.position, position, speed);
		}
	}
}

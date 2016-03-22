using UnityEngine;
using System.Collections;

public class BossThree_Movement : MonoBehaviour {

	enum B3State { Idle, ThrowAttack, Spin, Prep, Charge, Stun, Die };

	public GameObject knifePreFab;
	float startx;
	float starty;

	//Rigidbody2D rbody;
	Animator anim;
	B3State currstate;
	Transform target; //target Wallow

	int timer;
	int attackno;
	int health;
	int hitblink;

	// Use this for initialization
	void Start () {
		//rbody = GetComponent<Rigidbody2D> ();
		anim = GetComponent<Animator> ();
		anim.SetBool("Under_Half", false);
		anim.SetBool("Hit_Blink", false);
		target = GameObject.FindWithTag("Player").transform; //target the player
		startx = transform.position.x;
		starty = transform.position.y;

		currstate = B3State.Idle;
		timer = 120;
		attackno = 0;
		health = 100;
		hitblink = 0;
	}
	
	// Update is called once per frame
	void Update () {
		//Reduce Timer for current action
		timer--;
		//Update current action
		switch (currstate)
		{
		//Idle
		case B3State.Idle:
			if (timer <= 0) {
				attackno++;
				if ((attackno % 3) == 0) {
					timer = 60;
					currstate = B3State.ThrowAttack;
				} else if ((attackno % 3) == 1) {
					timer = 180;
					currstate = B3State.Spin;
				} else {
					timer = 120;
					currstate = B3State.Prep;
				}
			}
			break;
			//ThrowAttack
		case B3State.ThrowAttack:
			if (timer <= 0) {
				timer = 120;
				currstate = B3State.Idle;
			} else if ((timer % 15) == 3) {
				GameObject Clone;
				if (target.transform.position.x < transform.position.x) {
					Clone = (Instantiate (knifePreFab, (transform.position - transform.up
					- transform.right), transform.rotation)) as GameObject;
				} else {
					Clone = (Instantiate (knifePreFab, (transform.position - transform.up
						+ transform.right), transform.rotation)) as GameObject;
				}
			}
			break;
			//Spin
		case B3State.Spin:
			if (timer <= 0) {
				timer = 120;
				currstate = B3State.Stun;
			} else {
				//Chase Wallow
				if (target.transform.position.x < transform.position.x) {
					transform.position -= transform.right * 4 * Time.deltaTime; 
				} else if (target.transform.position.x > transform.position.x) {
					transform.position += transform.right * 4 * Time.deltaTime; 
				}
				if (target.transform.position.y < transform.position.y) {
					transform.position -= transform.up * 4 * Time.deltaTime; 
				} else if (target.transform.position.y > transform.position.y) {
					transform.position += transform.up * 4 * Time.deltaTime; 
				}
			}
			break;
			//Prep
		case B3State.Prep:
			if (timer <= 0) {
				timer = 240;
				currstate = B3State.Charge;
			} else {
				if (target.transform.position.x < transform.position.x) {
					transform.position -= transform.right * 4 * Time.deltaTime; 
				} else if (target.transform.position.x > transform.position.x) {
					transform.position += transform.right * 4 * Time.deltaTime; 
				}
			}
			break;
			//Charge
		case B3State.Charge:
			if (timer <= 0) {
				timer = 120;
				currstate = B3State.Stun;
			} else {
				transform.position -= transform.up * 12 * Time.deltaTime;
			}
			break;
			//Stun
		case B3State.Stun:
			if (timer <= 0) {
				timer = 120;
				currstate = B3State.Idle;
				//Teleport back to spawn
				transform.position = new Vector2(startx, starty);
			}
			break;
			//Death
		case B3State.Die:
			if (timer <= 0){
				Destroy (this.gameObject);
			}
			break;
		}
		//Update Animator States
		if (hitblink > 0){
			anim.SetBool("Hit_Blink", true);
			hitblink--;
		}else{
			anim.SetBool("Hit_Blink", false);
		}
		float i = (float)currstate;
		anim.SetFloat("State_Flag", i);
	}

	//Collision Check
	void OnCollisionEnter2D(Collision2D other)
	{
		if (other.gameObject.tag == "Player")
		{
			if(currstate == B3State.Spin || currstate == B3State.ThrowAttack
				|| currstate == B3State.Charge)
			{
				//other.gameObject.SendMessage("ApplyDamage", 1);
			}else if (currstate == B3State.Stun){
				ApplyDamage (10);
			}
		}
		if (other.gameObject.tag == "Arena" && (currstate == B3State.Charge)) {
			timer = 120;
			currstate = B3State.Stun;
		}
	}

	//Take Damage
	void ApplyDamage(int damageamount)
	{
		if ((hitblink <= 0) && ((currstate == B3State.Idle) || (currstate == B3State.Stun)))
		{
			hitblink = 30;
			anim.SetBool("Hit_Blink", true);
			health -= damageamount;
			if (health <= 0){
				timer = 30;
				hitblink = 0;
				anim.SetBool("Hit_Blink", false);
				currstate = B3State.Die;
			}else if (health <= 50){
				anim.SetBool("Under_Half", true);
			}
		}
	}
}

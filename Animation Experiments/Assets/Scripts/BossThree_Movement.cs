using UnityEngine;
using System.Collections;

public class BossThree_Movement : MonoBehaviour {

	enum B3State { Idle, ThrowAttack, Spin, Prep, Charge, Stun, Die };

	public GameObject knifePreFab;
	public GameObject sardinePreFab;
	public AudioClip hitSound;
	public AudioClip dieSound;
	private AudioSource source;
	private float volLowRange = .5f;
	private float volHighRange = 1.0f;

	bool sardinesab;
	bool tieshoesab;
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
		source = GetComponent<AudioSource>();
		anim = GetComponent<Animator> ();
		anim.SetBool("Under_Half", false);
		anim.SetBool("Hit_Blink", false);
		target = GameObject.FindWithTag("Player").transform; //target the player
		startx = transform.position.x;
		starty = transform.position.y;

		SetIdle ();
		attackno = 3;
		health = 20;
		hitblink = 0;

		//Sabotages
		//Replace these with the get function
		sardinesab = true;
		tieshoesab = false;
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
					SetThrowAttack ();
				} else if ((attackno % 3) == 1) {
					SetSpin ();
				} else {
					SetPrep ();
				}
			}
			break;
			//ThrowAttack
		case B3State.ThrowAttack:
			if (timer <= 0) {
				SetIdle ();
			} else if ((timer % 30) == 3) {
				GameObject Clone;

				/*if(sardinesab){
				if (target.transform.position.x < transform.position.x) {
					Clone = (Instantiate (sardinePreFab, (transform.position - transform.up
					- transform.right), transform.rotation)) as GameObject;
				} else {
					Clone = (Instantiate (sardinePreFab, (transform.position - transform.up
						+ transform.right), transform.rotation)) as GameObject;
				}
				}*/
				//else{
				if (target.transform.position.x < transform.position.x) {
					Clone = (Instantiate (knifePreFab, (transform.position - transform.up
						- transform.right), transform.rotation)) as GameObject;
				} else {
					Clone = (Instantiate (knifePreFab, (transform.position - transform.up
						+ transform.right), transform.rotation)) as GameObject;
				}
				//}

			}
			break;
			//Spin
		case B3State.Spin:
			if (timer <= 0) {
				SetStun ();
			} else if (timer % 4 == 0) {
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
				SetCharge ();
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
				SetStun ();
			}else if(tieshoesab){
				SetStun();
			} else {
				transform.position -= transform.up * 12 * Time.deltaTime;
			}
			break;
			//Stun
		case B3State.Stun:
			if (timer <= 0) {
				SetIdle ();
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
		}//End State Update
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
				other.gameObject.SendMessage("ApplyDamage", 1);
			}
		}
		else if(currstate == B3State.Charge) {
			SetStun ();
		}
	}

	//Take Damage
	void ApplyDamage(int damageamount)
	{
		if ((hitblink <= 0) && ((currstate == B3State.Idle) || (currstate == B3State.Stun)))
		{
			float vol = Random.Range (volLowRange, volHighRange);
			source.PlayOneShot(hitSound,vol);
			hitblink = 30;
			anim.SetBool("Hit_Blink", true);
			health -= damageamount;
			if (health <= 0){
				hitblink = 0;
				anim.SetBool("Hit_Blink", false);
				SetDie ();
			}else if (health <= 50){
				anim.SetBool("Under_Half", true);
			}
		}
	}

	void SetIdle(){
		timer = 100;
		currstate = B3State.Idle;
	}
	void SetThrowAttack(){
		timer = 60;
		currstate = B3State.ThrowAttack;
	}
	void SetSpin(){
		timer = 180;
		currstate = B3State.Spin;
	}
	void SetPrep(){
		timer = 80;
		currstate = B3State.Prep;
	}
	void SetCharge(){
		timer = 120;
		currstate = B3State.Charge;
	}
	void SetStun(){
		timer = 120;
		currstate = B3State.Stun;
	}
	void SetDie(){
		timer = 30;
		float vol = Random.Range (volLowRange, volHighRange);
		source.PlayOneShot(dieSound,vol);
		currstate = B3State.Die;
	}
}

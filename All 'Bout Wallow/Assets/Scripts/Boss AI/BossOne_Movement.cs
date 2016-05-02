using UnityEngine;
using System.Collections;

public class BossOne_Movement : MonoBehaviour {

	enum B1State { Idle, Align, Attack, Tired, Stun, Rage, Die };

	float startx;
	float starty;

	public GameObject downfirePreFab;
	public GameObject flashfirePreFab;
	public AudioClip hitSound;
	public AudioClip dieSound;
	private AudioSource source;
	private float volLowRange = .5f;
	private float volHighRange = 1.0f;
	public GameObject exit;
	//public bool sabget;

	//Rigidbody2D rbody;
	Animator anim;
	B1State currstate;
	Transform target; //target Wallow

	int timer;
	int attackno;
	int health;
	int hitblink;

	// Use this for initialization
	void Start () {
		anim = GetComponent<Animator> ();
		source = GetComponent<AudioSource>();
		anim.SetBool("Hit_Blink", false);
		target = GameObject.FindWithTag("Player").transform; //target the player
		startx = transform.position.x;
		starty = transform.position.y;

		SetRage ();
		// check for cake eating sabotage BEGIN
		if(GameManager.instance.getFireBreatherAteCake()==true)
			health = 8;
		else
			health = 6;
		// END
		hitblink = 0;
	}
	
	// Update is called once per frame
	void Update () {
		//Reduce Timer for current action
		timer--;
		//Update current action
		switch (currstate) {
			//Idle
		case B1State.Idle:
			if (timer <= 0) {
				SetAlign();
			}
			break;
			//Align
		case B1State.Align:
			if (timer <= 0) {
				SetAttack();
			} else {
				if (target.transform.position.x < (transform.position.x-0.1)) {
					transform.position -= transform.right * 4 * Time.deltaTime; 
				} else if (target.transform.position.x > (transform.position.x+0.1)) {
					transform.position += transform.right * 4 * Time.deltaTime; 
				}
			}
			break;
			//Attack
		case B1State.Attack:
			if (timer <= 0) {
				//Create fireball
				GameObject Clone;
				Clone = (Instantiate (downfirePreFab, (transform.position - transform.up),
					transform.rotation)) as GameObject;
				if (attackno < 3) {
					SetAlign();
				} else {
					SetTired();
				}
			}
			break;
			//Tired
		case B1State.Tired:
			if (timer <= 0) {
				SetAlign();
			}
			break;
			//Stun
		case B1State.Stun:
			if (timer <= 0) {
				SetRage();
			}
			break;
			//Rage
		case B1State.Rage:
			if (timer <= 0) {
				//Create the side fireballs
				GameObject Clone;
				Clone = (Instantiate (flashfirePreFab, (transform.position - transform.up),
					transform.rotation)) as GameObject;
				Clone = (Instantiate (flashfirePreFab, (transform.position - transform.right),
					transform.rotation)) as GameObject;
				Clone = (Instantiate (flashfirePreFab, (transform.position + transform.right),
					transform.rotation)) as GameObject;
				Clone = (Instantiate (flashfirePreFab, (transform.position - transform.up + transform.right),
					transform.rotation)) as GameObject;
				Clone = (Instantiate (flashfirePreFab, (transform.position - transform.up - transform.right),
					transform.rotation)) as GameObject;
				SetIdle();
			}
			break;
			//Die
		case B1State.Die:
			if (timer <= 0){
				Destroy (this.gameObject);
				exit.SetActive(true);
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
		anim.SetFloat ("State_Flag", i);
	}
		
	void ApplyDamage(int damageamount){

		if (currstate == B1State.Align || currstate == B1State.Attack
			|| currstate == B1State.Tired) {
			SetStun ();
		}
		if ((hitblink <= 0) && (currstate == B1State.Stun)) {
			hitblink = 30;
			float vol = Random.Range (volLowRange, volHighRange);
			anim.SetBool("Hit_Blink", true);
			health -= damageamount;
			if (health <= 0) {
				source.PlayOneShot (dieSound, vol);
				SetDie ();
			} else {
				source.PlayOneShot (hitSound, vol);
			}
		}
	}

	void SetIdle(){
		timer = 60;
		currstate = B1State.Idle;
		attackno = 0;
	}
	void SetAlign(){
		timer = 80;
		currstate = B1State.Align;
	}
	void SetAttack(){
		timer = 20;
		currstate = B1State.Attack;
		attackno++;
	}
	void SetTired(){
		timer = 120;
		currstate = B1State.Tired;
		attackno = 0;
	}
	void SetStun(){
		timer = 120;
		currstate = B1State.Stun;
		attackno = 0;
	}
	void SetRage(){
		timer = 60;
		currstate = B1State.Rage;
		attackno = 0;
	}
	void SetDie(){
		timer = 30;
		currstate = B1State.Die;
	}
}
